using System;
using System.Collections.Generic;
using System.Text;
using SmartIrrigationModels.Models.Geocoding;

namespace SmartIrrigation.Application.Geocoding
{
    public interface IGeocodingApplication
    {
        void GetCoordsFromAddress(GeocodingAddressModelQueryParams queryparams);
        void GetAddressFromCoords(string latitude, string longitude);
    }
}
