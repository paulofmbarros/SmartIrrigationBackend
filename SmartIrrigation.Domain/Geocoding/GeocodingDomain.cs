using System;
using System.Collections.Generic;
using System.Text;
using PositionStackAPI.ForwardGeocoding;
using PositionStackAPI.ReverseGeocoding;
using SmartIrrigationModels.Models.Geocoding;

namespace SmartIrrigation.Domain.Geocoding
{
    public class GeocodingDomain:IGeocodingDomain
    {

        private readonly IReverseGeocoding _reverseGeocoding;
        private readonly IForwardGeocodingService _forwardGeocoding;

        public GeocodingDomain(IReverseGeocoding reverseGeocoding, IForwardGeocodingService forwardGeocoding)
        {
            _reverseGeocoding = reverseGeocoding;
            _forwardGeocoding = forwardGeocoding;
        }

        public void GetCoordsFromAddress(GeocodingAddressModelQueryParams queryparams) =>
            _forwardGeocoding.GetCoordsFromAddress(queryparams);



        public void GetAddressFromCoords(string latitude, string longitude) =>
            _reverseGeocoding.GetAddressFromCoords(latitude, longitude);


    }
}
