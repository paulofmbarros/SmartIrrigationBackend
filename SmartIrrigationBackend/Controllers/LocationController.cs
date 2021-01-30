using Microsoft.AspNetCore.Mvc;
using SmartIrrigation.Application.BasicCRUD.Location;
using SmartIrrigationModels.Models.DTOS;
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
        public IActionResult SaveNewLocation([FromBody] GeocodingAddressModelQueryParams parameters)
        {
            _locationApplication.SaveNewLocation(parameters);
            return Ok();
        }

        [HttpGet("RetrieveLocation")]
        public IActionResult RetrieveLocation([FromQuery] string latitude, string longitude)
        {
            Location location = _locationApplication.RetrieveLocation(latitude, longitude);
            if (location != null)
            {
                return Ok(location);
            }

            return NotFound("Location Not Found in the database");
        }

        [HttpGet("RetrieveLocationByNodeId")]
        public IActionResult RetrieveLocationByNodeId(int nodeId)
        {
            Location location = _locationApplication.RetrieveLocationByNodeId(nodeId);
            if (location != null)
            {
                return Ok(location);
            }

            return NotFound("Location Not Found in the database");
        }
    }
}