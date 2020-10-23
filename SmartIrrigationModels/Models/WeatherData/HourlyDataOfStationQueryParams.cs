using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIrrigationModels.Models.WeatherData
{
    public class HourlyDataOfStationQueryParams
    {
        public string Station { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public string? Tz { get; set; } = "UTC";
        public int? Model { get; set; } = 0;


    }
}
