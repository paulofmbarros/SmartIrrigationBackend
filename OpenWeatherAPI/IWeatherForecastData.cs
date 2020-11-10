using System;
using System.Collections.Generic;
using System.Text;
using SmartIrrigationModels.Models;
using SmartIrrigationModels.Models.WeatherForecast;

namespace OpenWeatherAPI
{
    public interface IWeatherForecastData
    {
        RootWeatherForecast<Daily> GetWeatherForecast(string latitude, string longitude);
    }
}
