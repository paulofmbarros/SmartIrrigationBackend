using System;
using System.Collections.Generic;
using System.Text;
using SmartIrrigationModels.Models.Geocoding;

namespace SmartIrrigationModels.Models
{
    public class RootGeocodingDataModel<T> where T : GeocodingAddressResponseModel
    {
        public List<T> Data { get; set; }
    }
}
