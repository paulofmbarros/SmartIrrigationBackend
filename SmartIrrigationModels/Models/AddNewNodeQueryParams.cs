using System;
using System.Collections.Generic;
using System.Text;
using SmartIrrigationModels.Models.Geocoding;

namespace SmartIrrigationModels.Models
{
    public class AddNewNodeQueryParams :GeocodingAddressModelQueryParams
    {
        public bool IsRealSensor { get; set; }
        public string[]? SensorsImplemented { get; set; }
    }
}
