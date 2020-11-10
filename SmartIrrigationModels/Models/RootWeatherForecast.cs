using System;
using System.Collections.Generic;
using System.Text;
using SmartIrrigationModels.Models.WeatherForecast;

namespace SmartIrrigationModels.Models
{
    public class RootWeatherForecast<T> where T : Daily
    {
        public string Lat { get; set; }
        public string Long { get; set; }
        public string Timezone { get; set; }
        public List<T> Daily { get; set; }
    }
}
