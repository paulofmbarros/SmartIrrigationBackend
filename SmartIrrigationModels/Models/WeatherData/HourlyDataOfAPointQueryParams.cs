using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIrrigationModels.Models.WeatherData
{
   public class HourlyDataOfAPointQueryParams
    {
        public float Lat { get; set; }
        public float Long { get; set; }

        public int? Alt { get; set; }
        public string Start { get; set; }

        public string End { get; set; }
        public string? Tz { get; set; } = "UTC";
        

    }
}
