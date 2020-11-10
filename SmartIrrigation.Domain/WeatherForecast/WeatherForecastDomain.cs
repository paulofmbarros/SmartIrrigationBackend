using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using OpenWeatherAPI;
using SmartIrrigationModels.Models;
using SmartIrrigationModels.Models.WeatherForecast;

namespace SmartIrrigation.Domain
{
    public class WeatherForecastDomain : IWeatherForecastDomain
    {
        private readonly IWeatherForecastData _weatherForecastData;

        public WeatherForecastDomain(IWeatherForecastData weatherForecastData)
        {
            _weatherForecastData = weatherForecastData;
        }

        public RootWeatherForecast<Daily> GetWeatherForecast(string latitude, string longitude) =>
            _weatherForecastData.GetWeatherForecast(latitude, longitude);


    }
}
