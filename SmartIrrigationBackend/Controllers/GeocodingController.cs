using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartIrrigation.Application.Geocoding;
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
            _geocodingApplication.GetCoordsFromAddress(queryparams);
            return Ok();
        }

        [HttpGet("ReverseGeocoding")]
        public IActionResult GetAdressFromCoords(string latitude, string longitude)
        {
            _geocodingApplication.GetAddressFromCoords(latitude,longitude);

            return Ok();
        }
    }
}
