using System;
using System.Collections.Generic;
using System.Text;
using SmartIrrigationModels.Models.Geocoding;

namespace SmartIrrigation.Domain.Geocoding
{
    public interface IGeocodingDomain
    {
        void GetCoordsFromAddress(GeocodingAddressModelQueryParams queryparams);
        void GetAddressFromCoords(string latitude, string longitude);
    }
}
