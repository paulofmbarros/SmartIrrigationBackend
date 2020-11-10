using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace SmartIrrigationModels.Models.WeatherForecast
{
    public class Temperature
    {
        public float? Day { get; set; }
        public float? Min { get; set; }
        public float? Max { get; set; }
        public float? Night { get; set; }
        public float? Eve { get; set; }
        public float? Morn { get; set; }
    }
}
