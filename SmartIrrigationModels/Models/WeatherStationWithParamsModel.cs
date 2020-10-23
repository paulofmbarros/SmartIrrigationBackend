using System;
using System.Collections.Generic;
using System.Text;
using SmartIrrigationModels.Models.WeatherStation;

namespace SmartIrrigationModels.Models
{
    public class WeatherStationWithParamsModel :WeatherStationModel
    {
        public string? Country { get; set; }
        public string? Region { get; set; }
        public string? National { get; set; }
        public int? Wmo { get; set; }
        public string? Icao { get; set; }
        public string? Iata { get; set; }
        public float? Latitude { get; set; }
        public float? Longitude { get; set; }
        public int? Elevation { get; set; }
        public string? Timezone { get; set; }
    }
}
