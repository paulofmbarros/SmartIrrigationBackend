using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIrrigationModels.Models.WeatherData
{
    public class DailyDataModel : WeatherModel
    {
        public string? Date { get; set; }
        public float? Tavg { get; set; }
        public float? Tmin { get; set; }
        public float? Tmax { get; set; }
        public int? Snow { get; set; }
        public int? Wdir { get; set; }
        public float? Wspd { get; set; }
        public float? Wpgt{ get; set; }



    }
}
