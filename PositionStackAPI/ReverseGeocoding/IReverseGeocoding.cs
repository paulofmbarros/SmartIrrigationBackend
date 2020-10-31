using System;
using System.Collections.Generic;
using System.Text;
using SmartIrrigationModels.Models;
using SmartIrrigationModels.Models.Geocoding;

namespace PositionStackAPI.ReverseGeocoding
{
    public interface IReverseGeocoding
    {
        RootGeocodingDataModel<GeocodingAddressResponseModel> GetAddressFromCoords(string latitude, string longitude);
    }
}
