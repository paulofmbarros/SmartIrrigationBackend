using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIrrigationModels.Models.Geocoding
{
    public class GeocodingAddressModelQueryParams
    {
        public string Street { get; set; }
        public int? Door_Number { get; set; } 
        public string Postal_Code { get; set; }
        public string? County { get; set; }
        public string? District { get; set; }
    }
}
