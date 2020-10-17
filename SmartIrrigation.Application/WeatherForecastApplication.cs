using System;
using System.Collections.Generic;
using System.Text;
using SmartIrrigation.Domain;

namespace SmartIrrigation.Application
{
    public class WeatherForecastApplication : IWeatherForecastApplication
    {
        private readonly IWeatherForecastDomain _weatherForecastDomain;
        public WeatherForecastApplication(IWeatherForecastDomain weatherForecastDomain)
        {
            _weatherForecastDomain = weatherForecastDomain;
        }
    }
}
