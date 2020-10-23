using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace SmartIrrigationModels.Models.WeatherData
{
    public class WeatherModel
    {
        public float? Prcp { get; set; }
        public float? Pres { get; set; }
        public int? Tsun { get; set; }

    }
}
