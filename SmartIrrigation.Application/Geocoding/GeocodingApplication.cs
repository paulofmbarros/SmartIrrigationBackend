using System;
using System.Collections.Generic;
using System.Text;
using SmartIrrigation.Domain.Geocoding;
using SmartIrrigationModels.Models;
using SmartIrrigationModels.Models.Geocoding;

namespace SmartIrrigation.Application.Geocoding
{
    public class GeocodingApplication : IGeocodingApplication
    {
        private readonly IGeocodingDomain _geocodongDomain;

        public GeocodingApplication(IGeocodingDomain geocodongDomain)
        {
            _geocodongDomain = geocodongDomain;
        }

        public RootGeocodingDataModel<GeocodingAddressResponseModel> GetCoordsFromAddress(GeocodingAddressModelQueryParams queryparams) =>
            _geocodongDomain.GetCoordsFromAddress(queryparams);



        public RootGeocodingDataModel<GeocodingAddressResponseModel> GetAddressFromCoords(string latitude, string longitude) =>
            _geocodongDomain.GetAddressFromCoords(latitude, longitude);


    }
}
