using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIrrigationModels.Models.WeatherData
{
    public class DailyDataOfAPointQueryParams
    {
        public float Lat { get; set; }
        public float Long { get; set; }

        public int? Alt { get; set; }
        public string Start { get; set; }

        public string End { get; set; }
    }
}
