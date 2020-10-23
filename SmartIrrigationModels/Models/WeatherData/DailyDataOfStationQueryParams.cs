using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIrrigationModels.Models.WeatherData
{
    public class DailyDataOfStationQueryParams
    {
        public string Station { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
    }
}
