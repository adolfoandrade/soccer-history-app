using app.api.Infrastructure;
using App.Domain.Interfaces;
using App.EventBus;
using App.EventBus.EventBusRabbitMQ;
using App.EventBus.IntegrationEvents.EventHandling;
using App.EventBus.IntegrationEvents.Services;
using App.Infra.Data;
using App.Infra.Data.Repository;
using App.Service;
using App.Service.Interfaces;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using RabbitMQ.Client;
using System;

namespace App.Admin.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.Configure<AppSettings>(Configuration.GetSection("SqlConnectionSettings"));
            services.AddSingleton<IDbConnectionFactory, SqlConnectionFactory>();

            services.AddScoped<IMatchRepository, MatchRepository>();
            services.AddScoped<ISoccerTeamRepository, SoccerTeamRepository>();
            services.AddScoped<ISoccerTeamService, SoccerTeamService>();

            services.AddScoped<ICompetitionRepository, CompetitionRepository>();
            services.AddScoped<ICompetitionService, CompetitionService>();

            services.AddScoped<ISoccerEventRepository, SoccerEventRepository>();
            services.AddScoped<ISoccerEventService, SoccerEventService>();

            services.AddScoped<ISoccerTeamEventCardRepository, SoccerTeamEventCardRepository>();
            services.AddScoped<IStatisticGoalsService, StatisticGoalsService>();

            services.AddScoped<ISoccerTeamEventGolRepository, SoccerTeamEventGolRepository>();
            services.AddScoped<IStatisticCardsService, StatisticCardsService>();

            services.AddScoped<IStatisticRepository, StatisticRepository>();
            services.AddScoped<ICommonStatisticService, CommonStatisticService>();

            services.AddScoped<IEventTimeStatisticRepository, EventTimeStatisticRepository>();
            services.AddScoped<IMatchEventsRepository, MatchEventsRepository>();

            services.AddScoped<ICompetitionIntegrationEventService, CompetitionIntegrationEventService>();
            services.AddScoped<ITeamsIntegrationEventService, TeamsIntegrationEventService>();
            services.AddScoped<IFixtureIntegrationEventService, FixtureIntegrationEventService>();
            services.AddScoped<IFixtureStatisticIntegrationEventService, FixtureStatisticIntegrationEventService>();
            services.AddScoped<IFixtureEventsIntegrationEventService, FixtureEventsIntegrationEventService>();

            services.AddScoped<IApiValueReferenceRepository, ApiValueReferenceRepository>();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:3000",
                                            "http://localhost:3001",
                                            "http://localhost:3002",
                                            "http://localhost:4222",
                                            "https://localhost:5001",
                                            "http://www.contoso.com")
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                    });
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "App.Admin.Api", Version = "v1" });
            });

            services.AddIntegrationServices(Configuration)
                    .AddEventBus(Configuration);

            var container = new ContainerBuilder();
            container.Populate(services);
            container.Build();
        }

        protected virtual void ConfigureEventBus(IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
            eventBus.Subscribe<CompetitionIntegrationEvent, CompetitionIntegrationEventHandler>();
            eventBus.Subscribe<TeamsIntegrationEvent, TeamsIntegrationEventHandler>();
            eventBus.Subscribe<FixtureStatisticsIntegrationEvent, FixtureStatisticsIntegrationEventHandler>();
            eventBus.Subscribe<FixtureIntegrationEvent, FixtureIntegrationEventHandler>();
            eventBus.Subscribe<FixtureEventsIntegrationEvent, FixtureEventsIntegrationEventHandler>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "App.Admin.Api v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            ConfigureEventBus(app);
        }

    }

    public static class CustomExtensionMethods
    {
        public static IServiceCollection AddIntegrationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IRabbitMQPersistentConnection>(sp =>
            {
                var logger = sp.GetRequiredService<ILogger<DefaultRabbitMQPersistentConnection>>();

                var factory = new ConnectionFactory()
                {
                    HostName = configuration["EventBusConnection"],
                    DispatchConsumersAsync = true
                };

                if (!string.IsNullOrEmpty(configuration["EventBusUserName"]))
                {
                    factory.UserName = configuration["EventBusUserName"];
                }

                if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("SOCCER_APP_RABBITMQ_PASSWORD")))
                {
                    factory.Password = Environment.GetEnvironmentVariable("SOCCER_APP_RABBITMQ_PASSWORD");
                }

                var retryCount = 5;
                if (!string.IsNullOrEmpty(configuration["EventBusRetryCount"]))
                {
                    retryCount = int.Parse(configuration["EventBusRetryCount"]);
                }

                return new DefaultRabbitMQPersistentConnection(factory, logger, retryCount);
            });

            return services;
        }

        public static IServiceCollection AddEventBus(this IServiceCollection services, IConfiguration configuration)
        {
            var subscriptionClientName = configuration["SubscriptionClientName"];

            services.AddSingleton<IEventBus, EventBusRabbitMQ>(sp =>
            {
                var rabbitMQPersistentConnection = sp.GetRequiredService<IRabbitMQPersistentConnection>();
                var iLifetimeScope = sp.GetRequiredService<ILifetimeScope>();
                var logger = sp.GetRequiredService<ILogger<EventBusRabbitMQ>>();
                var eventBusSubcriptionsManager = sp.GetRequiredService<IEventBusSubscriptionsManager>();

                var retryCount = 5;
                if (!string.IsNullOrEmpty(configuration["EventBusRetryCount"]))
                {
                    retryCount = int.Parse(configuration["EventBusRetryCount"]);
                }

                return new EventBusRabbitMQ(rabbitMQPersistentConnection, logger, iLifetimeScope, eventBusSubcriptionsManager, subscriptionClientName, retryCount);
            });

            services.AddSingleton<IEventBusSubscriptionsManager, InMemoryEventBusSubscriptionsManager>();
            services.AddTransient<CompetitionIntegrationEventHandler>();
            services.AddTransient<TeamsIntegrationEventHandler>();
            services.AddTransient<FixtureIntegrationEventHandler>();
            services.AddTransient<FixtureEventsIntegrationEventHandler>();
            services.AddTransient<FixtureStatisticsIntegrationEventHandler>();

            return services;
        }
    }

}