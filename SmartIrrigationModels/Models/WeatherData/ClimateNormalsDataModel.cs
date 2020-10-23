using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIrrigationModels.Models.WeatherData
{
    public class ClimateNormalsDataModel : WeatherModel
    {
        public string? Month { get; set; }
        public float? Tavg { get; set; }
        public string? Tmin { get; set; }
        public string? Tmax { get; set; }

    }
}
