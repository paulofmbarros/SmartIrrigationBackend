using System;
using System.Collections.Generic;
using System.Text;
using SmartIrrigationModels.Models.Geocoding;

namespace PositionStackAPI.ForwardGeocoding
{
    public interface IForwardGeocodingService
    {
        void GetCoordsFromAddress(GeocodingAddressModelQueryParams queryparams);
    }
}
