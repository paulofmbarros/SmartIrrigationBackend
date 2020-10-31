using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIrrigationModels.Models.Geocoding
{
    public class GeocodingAddressResponseModel
    {
        public string? Latitude  { get; set; }
        public string? Longitude  { get; set; }
        public string? Label  { get; set; }
        public string? Name  { get; set; }
        public string? Type  { get; set; }
        public float? Distance  { get; set; }
        public string? Number  { get; set; }
        public string? Street  { get; set; }
        public string? Postal_Code  { get; set; }
        public float? Confidence  { get; set; }
        public string? Region  { get; set; }
        public string? Region_Code  { get; set; }
        public string? Administrative_Area { get; set; }
        public string? Neighbourhood { get; set; }
        public string? Country { get; set; }
        public string? Country_Code { get; set; }
        public string? Map_Url { get; set; }

    }
}
