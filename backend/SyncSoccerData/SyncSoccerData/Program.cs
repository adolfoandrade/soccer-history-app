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
            var _client = container.Resolve<IApiFootballBaseClient>();
            //var countries = new List<string>() { "Brazil", "Colombia", "Chile", "Venezuela", "Argentina", "Uruguay", "Bolivia", "Ecuador", "Peru", "Paraguay" };
            var countries = new List<string>() { "Chile", "Venezuela" };

            foreach (var country in countries)
            {
                
                var leagues = _client.GetLeaguesAsync(country).Result;
                serviceBus.Publish(new CompetitionIntegrationEvent() { Competitions = JsonConvert.SerializeObject(leagues) });
                var ableLeagues = leagues.Response.Where(x => x.Seasons.Any(y => y.Year == 2022 && y.End.Date >= DateTime.Now.Date)).ToList();
                foreach (var league in ableLeagues)
                {
                    var teams = _client.GetTeamsAsync(league.LeagueVM.Id, 2022).Result;
                    serviceBus.Publish(new TeamsIntegrationEvent() { Teams = JsonConvert.SerializeObject(teams) });
                    //Task.Delay(TimeSpan.FromSeconds(15));
                    var fixtures = _client.GetFixturesAsync(league.LeagueVM.Id, 2022).Result;
                    serviceBus.Publish(new FixtureIntegrationEvent() { Fixtures = JsonConvert.SerializeObject(fixtures) });
                    Console.WriteLine($"Sending competition {league.LeagueVM.Name}");
                    foreach (var fixture in fixtures.Response)
                    {
                        var events = _client.GetFixtureEventsAsync(fixture.Fixture.Id).Result;
                        serviceBus.Publish(new FixtureEventsIntegrationEvent() { TheEvents = JsonConvert.SerializeObject(events), Fixture = fixture.Fixture.Id });
                        var statistics = _client.GetFixtureStatisticsAsync(fixture.Fixture.Id).Result;
                        serviceBus.Publish(new FixtureStatisticsIntegrationEvent() { Statistics = JsonConvert.SerializeObject(statistics), Fixture = fixture.Fixture.Id });
                    }
                    Console.WriteLine("Waiting 30 seconds");
                    Thread.Sleep(TimeSpan.FromSeconds(30));
                }
            }

            Console.WriteLine("Process finished");
            Console.ReadLine();
        }

    }

}
