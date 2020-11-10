using System;
using System.Collections.Generic;
using System.Text;
using SmartIrrigationModels.Models;
using SmartIrrigationModels.Models.WeatherForecast;

namespace SmartIrrigation.Application
{
    public interface IWeatherForecastApplication
    {
        RootWeatherForecast<Daily> GetWeatherForecast(string latitude, string longitude);
    }
}
