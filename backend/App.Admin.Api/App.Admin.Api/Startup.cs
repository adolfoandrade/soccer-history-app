using app.api.Infrastructure;
using App.Domain.Interfaces;
using App.Infra.Data;
using App.Infra.Data.Repository;
using App.Service;
using App.Service.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace App.Admin.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.Configure<AppSettings>(Configuration.GetSection("SqlConnectionSettings"));
            services.AddSingleton<IDbConnectionFactory, SqlConnectionFactory>();;

            services.AddScoped<IMatchRepository, MatchRepository>();
            services.AddScoped<ISoccerTeamRepository, SoccerTeamRepository>();
            services.AddScoped<ISoccerTeamService, SoccerTeamService>();

            services.AddScoped<ICompetitionRepository, CompetitionRepository>();
            services.AddScoped<ICompetitionService, CompetitionService>();

            services.AddScoped<ISoccerEventRepository, SoccerEventRepository>();
            services.AddScoped<ISoccerEventService, SoccerEventService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "App.Admin.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "App.Admin.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
