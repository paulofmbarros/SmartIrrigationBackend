using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIrrigationModels.Models
{
    public class FindNearbyStationModel
    {
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public int? Limit { get; set; } = 8;
        public int? Radius { get; set; } = 100;
    }
}
