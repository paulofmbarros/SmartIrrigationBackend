using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevMeteoStat;
using DevMeteoStat.WeatherStationsData;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OpenWeatherAPI;
using PositionStackAPI.ForwardGeocoding;
using PositionStackAPI.ReverseGeocoding;
using SmartIrrigation.Abstractions.Relational.Configuration;
using SmartIrrigation.Abstractions.Relational.Reads;
using SmartIrrigation.Application;
using SmartIrrigation.Application.BasicCRUD;
using SmartIrrigation.Application.BasicCRUD.Counties;
using SmartIrrigation.Application.BasicCRUD.Districts;
using SmartIrrigation.Application.Geocoding;
using SmartIrrigation.Application.WeatherStation;
using SmartIrrigation.Domain;
using SmartIrrigation.Domain.BasicCRUD;
using SmartIrrigation.Domain.BasicCRUD.Counties;
using SmartIrrigation.Domain.BasicCRUD.District;
using SmartIrrigation.Domain.Geocoding;
using SmartIrrigation.Domain.WeatherStation;
using SmartIrrigationConfigurationService;


namespace SmartIrrigationBackend
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
            //APPLICATION
            services.AddScoped<IWeatherForecastApplication, WeatherForecastApplication>();
            services.AddScoped<IWeatherStationApplication, WeatherStationApplication>();
            services.AddScoped<IGeocodingApplication, GeocodingApplication>();
            services.AddScoped<ICountiesApplication, CountiesApplication>();
            services.AddScoped<IDistrictApplication, DistrictApplication>();


            //DOMAIN
            services.AddScoped<IWeatherStationDomain, WeatherStationDomain>();
            services.AddScoped<IWeatherForecastDomain, WeatherForecastDomain>();
            services.AddScoped<IWeatherStationDomain, WeatherStationDomain>();
            services.AddScoped<IGeocodingDomain, GeocodingDomain>();
            services.AddScoped<ICountiesDomain, CountiesDomain>();
            services.AddScoped<IDistrictDomain, DistrictDomain>();

            //RELATIONAL
            services.AddScoped<IReadCountiesInformation, ReadCountiesInformation>();
            services.AddScoped<IReadDistrictInformation, ReadDistrictInformation>();


            //CONFIG
            services.AddScoped<IConfigRelational, ConfigRelational>();
            services.AddScoped<IConfig, Config>();

            //SHARED
            services.AddScoped<IWeatherForecastData, WeatherForecastData>();
            services.AddScoped<IWeatherStationsData, WeatherStationsData>();
            services.AddScoped<IPointData, PointData>();
            services.AddScoped<IForwardGeocodingService, ForwardGeocodingService>();
            services.AddScoped<IReverseGeocoding, ReverseGeocoding>();


            services.AddControllers();
            services.AddSwaggerGen();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            app.UseHttpsRedirection();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Smart Irrigation System Api");

            });


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
