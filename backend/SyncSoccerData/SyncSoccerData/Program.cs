using Autofac;
using Autofac.Core;
using Dapper;
using Newtonsoft.Json;
using RabbitMQ.Client;
using SyncSoccerData.EventBus;
using SyncSoccerData.EventBus.EventBusRabbitMQ;
using SyncSoccerData.EventBus.IntegrationEvents.EventHandling;
using SyncSoccerData.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SyncSoccerData
{
    internal class Program
    {
        public static string COUNTRIES_URL = "https://api-football-v1.p.rapidapi.com/v3/countries";
        public static string LEAGUES_URL = "https://api-football-v1.p.rapidapi.com/v3/leagues?country=Brazil";
        public static string TEAMS_URL = "https://api-football-v1.p.rapidapi.com/v3/teams?league=71&season=2022";
        public static string FIXTURES_URL = "https://api-football-v1.p.rapidapi.com/v3/fixtures?league=72&season=2022";
        public static string FIXTURE_EVENTS_URL = "https://api-football-v1.p.rapidapi.com/v3/fixtures/events?fixture=838627";

        static Program()
        {

        }

        static void Main(string[] args)
        {
            IContainer container;
            var firstBuilder = new ContainerBuilder();
            var builder = new ContainerBuilder();
            var subscriptionClientName = "SubscriptionClientName";
            var factory = new ConnectionFactory()
            {
                HostName = "spaceship-rabbitmq.brazilsouth.cloudapp.azure.com", //Configuration["EventBusConnection"],
                DispatchConsumersAsync = true
            };
            factory.UserName = "app";
            factory.Password = "";
            var retryCount = 5;
            firstBuilder.Register(x => new DefaultRabbitMQPersistentConnection(factory, retryCount)).As<IRabbitMQPersistentConnection>();
            firstBuilder.RegisterType<InMemoryEventBusSubscriptionsManager>().As<IEventBusSubscriptionsManager>();
            var containerAutofac = firstBuilder.Build();

            var rabbitMQPersistentConnection = containerAutofac.Resolve<IRabbitMQPersistentConnection>();
            var iLifetimeScope = containerAutofac.Resolve<ILifetimeScope>();
            var eventBusSubcriptionsManager = containerAutofac.Resolve<IEventBusSubscriptionsManager>();
            builder.Register(x => new EventBusRabbitMQ(rabbitMQPersistentConnection, iLifetimeScope, eventBusSubcriptionsManager, subscriptionClientName, retryCount)).As<IEventBus>();

            container = builder.Build();

            //var countries = GetAsync<CountriesResponseVM>(COUNTRIES_URL).Result;
            var leagues = GetAsync<ResponseVM<LeaguesResponseVM>>(LEAGUES_URL).Result;
            var teams = GetAsync<ResponseVM<TeamVenueResponseVM>>(TEAMS_URL).Result;
            //var fixtures = GetAsync<ResponseVM<FixtureLeagueResponseVM>>(FIXTURES_URL).Result;
            //var fixtureEvents = GetAsync<ResponseVM<FixtureEventsResponseVM>>(FIXTURE_EVENTS_URL).Result;

            var service = container.Resolve<IEventBus>();
            service.Publish(new CompetitionIntegrationEvent() { Competitions = JsonConvert.SerializeObject(leagues) });

            service.Publish(new TeamsIntegrationEvent() { Teams = JsonConvert.SerializeObject(teams) });

            Console.ReadLine();
        }

        static async Task<T> GetAsync<T>(string url)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("X-RapidAPI-Host", "api-football-v1.p.rapidapi.com");
            client.DefaultRequestHeaders.Add("X-RapidAPI-Key", "ea52f2423emsh6d54b6bd79841a1p1f7a4ejsn1922d7f49e50");

            var result = await client.GetStringAsync(url);
            return JsonConvert.DeserializeObject<T>(result);
        }
    }

}
