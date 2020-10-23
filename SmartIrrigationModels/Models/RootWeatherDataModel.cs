using System;
using System.Collections.Generic;
using System.Text;
using SmartIrrigationModels.Models.WeatherData;

namespace SmartIrrigationModels.Models
{
    public class RootWeatherDataModel<T> where  T : WeatherModel
    {
        public List<T> Data { get; set; }
    }
}
