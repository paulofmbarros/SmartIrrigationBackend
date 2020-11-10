using System;
using System.Collections.Generic;
using System.Text;
using SmartIrrigation.Domain;
using SmartIrrigationModels.Models;
using SmartIrrigationModels.Models.WeatherForecast;

namespace SmartIrrigation.Application
{
    public class WeatherForecastApplication : IWeatherForecastApplication
    {
        private readonly IWeatherForecastDomain _weatherForecastDomain;
        public WeatherForecastApplication(IWeatherForecastDomain weatherForecastDomain)
        {
            _weatherForecastDomain = weatherForecastDomain;
        }

        public RootWeatherForecast<Daily> GetWeatherForecast(string latitude, string longitude) => _weatherForecastDomain.GetWeatherForecast(latitude, longitude);


    }
}
