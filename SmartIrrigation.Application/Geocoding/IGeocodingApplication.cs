using System;
using System.Collections.Generic;
using System.Text;
using SmartIrrigationModels.Models;
using SmartIrrigationModels.Models.Geocoding;

namespace SmartIrrigation.Application.Geocoding
{
    public interface IGeocodingApplication
    {
        RootGeocodingDataModel<GeocodingAddressResponseModel> GetCoordsFromAddress(GeocodingAddressModelQueryParams queryparams);
        RootGeocodingDataModel<GeocodingAddressResponseModel> GetAddressFromCoords(string latitude, string longitude);
    }
}
