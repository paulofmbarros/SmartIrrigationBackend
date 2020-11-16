using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartIrrigation.Application.BasicCRUD.Location;
using SmartIrrigationModels.Models.Geocoding;

namespace SmartIrrigationBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationApplication _locationApplication;

        public LocationController(ILocationApplication locationApplication)
        {
            _locationApplication = locationApplication;
        }

        [HttpPost("SaveNewLocation")]
        public IActionResult SaveNewLocation(GeocodingAddressModelQueryParams parameters )
        {
            _locationApplication.SaveNewLocation(parameters);
            return Ok();
        }
    }
}
