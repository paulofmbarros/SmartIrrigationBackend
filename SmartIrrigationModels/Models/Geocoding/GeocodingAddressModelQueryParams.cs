using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIrrigationModels.Models.Geocoding
{
    public class GeocodingAddressModelQueryParams
    {
        public string Street { get; set; }
        public int? DoorNumber { get; set; } 
        public string PostalCode { get; set; }
        public string? County { get; set; }
        public string? District { get; set; }

        public GeocodingAddressModelQueryParams()
        {
            
        }

        public GeocodingAddressModelQueryParams(string street, int? doorNumber, string postalCode, string? county, string? district)
        {
            Street = street;
            DoorNumber = doorNumber;
            PostalCode = postalCode;
            County = county;
            District = district;
        }
    }
}
