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
            //var countries = new List<string>() { "Brazil", "Colombia", "Chile", "Venezuela", "Argentina", "Uruguay", "Bolivia", "Ecuador", "Peru" };
            var countries = new List<string>() { "Peru" };

            foreach (var country in countries)
            {
                
                var leagues = _client.GetLeaguesAsync(country).Result;
                //serviceBus.Publish(new CompetitionIntegrationEvent() { Competitions = JsonConvert.SerializeObject(leagues) });

                foreach (var league in leagues.Response)
                {
                    //var teams = _client.GetTeamsAsync(league.LeagueVM.Id, 2022).Result;
                    //serviceBus.Publish(new TeamsIntegrationEvent() { Teams = JsonConvert.SerializeObject(teams) });
                    //Task.Delay(TimeSpan.FromSeconds(15));
                    var fixtures = _client.GetFixturesAsync(league.LeagueVM.Id, 2022).Result;
                    foreach (var fixture in fixtures.Response)
                    {
                        var events = _client.GetFixtureEventsAsync(fixture.Fixture.Id).Result;
                    }
                }

                Task.Delay(TimeSpan.FromSeconds(60));
            }

            Console.ReadLine();
        }

    }

}
