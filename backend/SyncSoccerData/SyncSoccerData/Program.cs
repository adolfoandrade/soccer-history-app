using Autofac;
using Autofac.Core;
using Dapper;
using Newtonsoft.Json;
using RabbitMQ.Client;
using SyncSoccerData.Clients;
using SyncSoccerData.EventBus;
using SyncSoccerData.EventBus.EventBusRabbitMQ;
using SyncSoccerData.EventBus.IntegrationEvents.EventHandling;
using SyncSoccerData.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace SyncSoccerData
{
    internal class Program
    {
        static IApiFootballBaseClient _client;
        static IEventBus _Bus;

        static Program()
        {

        }

        static void Main(string[] args)
        {
            /* Dependecy Injection withutofac configuration */ 
            IContainer container;
            var firstBuilder = new ContainerBuilder();
            var builder = new ContainerBuilder();
            var subscriptionClientName = "SubscriptionClientName";
            var factory = new ConnectionFactory()
            {
                HostName = "spaceship-rabbitmq.brazilsouth.cloudapp.azure.com",
                DispatchConsumersAsync = true
            };
            factory.UserName = "soccer";
            factory.Password = Environment.GetEnvironmentVariable("SOCCER_APP_RABBITMQ_PASSWORD");
            var retryCount = 5;
            firstBuilder.Register(x => new DefaultRabbitMQPersistentConnection(factory, retryCount)).As<IRabbitMQPersistentConnection>();
            firstBuilder.RegisterType<InMemoryEventBusSubscriptionsManager>().As<IEventBusSubscriptionsManager>();
            var containerAutofac = firstBuilder.Build();

            var rabbitMQPersistentConnection = containerAutofac.Resolve<IRabbitMQPersistentConnection>();
            var iLifetimeScope = containerAutofac.Resolve<ILifetimeScope>();
            var eventBusSubcriptionsManager = containerAutofac.Resolve<IEventBusSubscriptionsManager>();
            builder.Register(x => new EventBusRabbitMQ(rabbitMQPersistentConnection, iLifetimeScope, eventBusSubcriptionsManager, subscriptionClientName, retryCount)).As<IEventBus>();
            builder.RegisterType<ApiFootballBaseClient>().As<IApiFootballBaseClient>();
            container = builder.Build();


            /* Query api and send data */
            var serviceBus = container.Resolve<IEventBus>();
            _Bus = container.Resolve<IEventBus>();
            _client = container.Resolve<IApiFootballBaseClient>();
            var countries = new List<string>() { "China", "Brazil", "Colombia", "Chile", "Venezuela", "Argentina", "Uruguay", "Bolivia", "Ecuador", "Peru", "Paraguay" };
            var coveredLeagues = new List<int>() { 71, 72, 75, 76, 73, 265, 711, 300, 299, 129, 128, 269, 268, 270, 344, 710, 243, 242, 281, 282, 251, 250,
            169,170 }; // Asia 

            UpdateFixturesAndStatistics(countries, coveredLeagues);
            //NewFullCompetitionWithTeamsFixturesAndStatistics(new List<string>() { "China" }, coveredLeagues);
        }

        static void UpdateFixturesAndStatistics(List<string> countries, List<int> coveredLeagues)
        {
            foreach (var country in countries)
            {
                var leagues = _client.GetLeaguesAsync(country).Result;
                leagues.Response = leagues.Response.Where(x => coveredLeagues.Any(y => y == x.LeagueVM.Id)).ToList();
                if (leagues.Response.Count > 0)
                {
                    var ableLeagues = leagues.Response.Where(x =>
                                                            x.Seasons.Any(y => y.Year == 2022 && y.End.Date >= DateTime.Now.Date)
                                                            && coveredLeagues.Any(y => y == x.LeagueVM.Id))
                                                            .ToList();
                    foreach (var league in ableLeagues)
                    {
                        var fixtures = _client.GetFixturesAsync(league.LeagueVM.Id, 2022).Result;
                        var ableFixtures = fixtures.Response.Where(x => x.Fixture.Date.AddDays(3) >= DateTime.Now.Date)
                                                            .ToList();
                        fixtures.Response = ableFixtures;
                        _Bus.Publish(new FixtureIntegrationEvent() { Fixtures = JsonConvert.SerializeObject(fixtures) });
                        Console.WriteLine($"Sending fixtures from competition {league.LeagueVM.Name} {league.CountryVM?.Name}");
                        foreach (var fixture in fixtures.Response)
                        {
                            var events = _client.GetFixtureEventsAsync(fixture.Fixture.Id).Result;
                            _Bus.Publish(new FixtureEventsIntegrationEvent() { TheEvents = JsonConvert.SerializeObject(events), Fixture = fixture.Fixture.Id });
                            if (league.Seasons.Any(x => x.Year == 2022 && x.Coverage.Fixtures.StatisticsFixtures) && fixture.Fixture.Status.Long == "Match Finished")
                            {
                                var statistics = _client.GetFixtureStatisticsAsync(fixture.Fixture.Id).Result;
                                _Bus.Publish(new FixtureStatisticsIntegrationEvent() { Statistics = JsonConvert.SerializeObject(statistics), Fixture = fixture.Fixture.Id });
                            }
                        }
                        Console.WriteLine("Waiting 30 seconds");
                        _Bus.Publish(new UpdateCompetitionStatisticIntegrationEvent() { CompetitionId = league.LeagueVM.Id });
                        Thread.Sleep(TimeSpan.FromSeconds(30));

                    }
                }

            }
            Console.WriteLine("Process finished");
            Console.ReadLine();
        }

        static void NewFullCompetitionWithTeamsFixturesAndStatistics(List<string> countries, List<int> coveredLeagues)
        {
            foreach (var country in countries)
            {
                var leagues = _client.GetLeaguesAsync(country).Result;
                leagues.Response = leagues.Response.Where(x => coveredLeagues.Any(y => y == x.LeagueVM.Id)).ToList();
                if (leagues.Response.Count > 0)
                {
                    _Bus.Publish(new CompetitionIntegrationEvent() { Competitions = JsonConvert.SerializeObject(leagues) });
                    var ableLeagues = leagues.Response.Where(x =>
                                                            x.Seasons.Any(y => y.Year == 2022 && y.End.Date >= DateTime.Now.Date)
                                                            && coveredLeagues.Any(y => y == x.LeagueVM.Id))
                                                            .ToList();
                    foreach (var league in ableLeagues)
                    {
                        var teams = _client.GetTeamsAsync(league.LeagueVM.Id, 2022).Result;
                        _Bus.Publish(new TeamsIntegrationEvent() { Teams = JsonConvert.SerializeObject(teams) });

                        var fixtures = _client.GetFixturesAsync(league.LeagueVM.Id, 2022).Result;
                        _Bus.Publish(new FixtureIntegrationEvent() { Fixtures = JsonConvert.SerializeObject(fixtures) });

                        Console.WriteLine($"Sending competition {league.LeagueVM.Name}");
                        foreach (var fixture in fixtures.Response)
                        {
                            var events = _client.GetFixtureEventsAsync(fixture.Fixture.Id).Result;
                            _Bus.Publish(new FixtureEventsIntegrationEvent() { TheEvents = JsonConvert.SerializeObject(events), Fixture = fixture.Fixture.Id });
                            if (league.Seasons.Any(x => x.Year == 2022 && x.Coverage.Fixtures.StatisticsFixtures) && fixture.Fixture.Status.Long == "Match Finished")
                            {
                                var statistics = _client.GetFixtureStatisticsAsync(fixture.Fixture.Id).Result;
                                _Bus.Publish(new FixtureStatisticsIntegrationEvent() { Statistics = JsonConvert.SerializeObject(statistics), Fixture = fixture.Fixture.Id });
                            }
                        }
                        Console.WriteLine("Waiting 30 seconds");
                        Thread.Sleep(TimeSpan.FromSeconds(30));
                    }
                }

            }
            Console.WriteLine("Process finished");
            Console.ReadLine();
        }
    }

}
