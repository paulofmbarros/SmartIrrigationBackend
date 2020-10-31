using System;
using System.Collections.Generic;
using System.Text;
using SmartIrrigationModels.Models;
using SmartIrrigationModels.Models.Geocoding;

namespace PositionStackAPI.ForwardGeocoding
{
    public interface IForwardGeocodingService
    {
        RootGeocodingDataModel<GeocodingAddressResponseModel> GetCoordsFromAddress(GeocodingAddressModelQueryParams queryparams);
    }
}
