using Microsoft.AspNetCore.Mvc;
using SmartIrrigation.Application.Geocoding;
using SmartIrrigationModels.Models;
using SmartIrrigationModels.Models.Geocoding;

namespace SmartIrrigationBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeocodingController : ControllerBase
    {
        private readonly IGeocodingApplication _geocodingApplication;

        public GeocodingController(IGeocodingApplication geocodingApplication)
        {
            _geocodingApplication = geocodingApplication;
        }

        [HttpGet("Geocoding")]
        public IActionResult GetCoordsFromAddress([FromQuery] GeocodingAddressModelQueryParams queryparams)
        {
            RootGeocodingDataModel<GeocodingAddressResponseModel> data = _geocodingApplication.GetCoordsFromAddress(queryparams);
            return Ok(data);
        }

        [HttpGet("ReverseGeocoding")]
        public IActionResult GetAdressFromCoords(string latitude, string longitude)
        {
            RootGeocodingDataModel<GeocodingAddressResponseModel> data = _geocodingApplication.GetAddressFromCoords(latitude, longitude);

            return Ok(data);
        }
    }
}