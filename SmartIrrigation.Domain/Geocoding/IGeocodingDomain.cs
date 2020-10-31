using System;
using System.Collections.Generic;
using System.Text;
using SmartIrrigationModels.Models;
using SmartIrrigationModels.Models.Geocoding;

namespace SmartIrrigation.Domain.Geocoding
{
    public interface IGeocodingDomain
    {
        RootGeocodingDataModel<GeocodingAddressResponseModel> GetCoordsFromAddress(GeocodingAddressModelQueryParams queryparams);
        RootGeocodingDataModel<GeocodingAddressResponseModel> GetAddressFromCoords(string latitude, string longitude);
    }
}
