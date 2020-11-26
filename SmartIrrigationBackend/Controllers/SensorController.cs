using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartIrrigation.Application.Sensor;
using SmartIrrigation.Application.WeatherForecast;
using SmartIrrigationModels.Models.Geocoding;

namespace SmartIrrigationBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorController : ControllerBase
    {
        private readonly ISensorApplication _sensorApplication;

        public SensorController(ISensorApplication sensorApplication)
        {
            _sensorApplication = sensorApplication;
        }

        /// <summary>
        /// Add a new Weather station to database
        /// </summary>
        /// <param name="findStationParams"></param>
        /// <returns></returns>
        [HttpPost("AddNewSensor")]
        public IActionResult AddNewSensor([FromBody] GeocodingAddressModelQueryParams address, bool isEnable = false)
        {
            var data = _sensorApplication.AddNewSensor(address, isEnable);
            if (data == -1)
            {
                return NotFound("Node not found for this Sensor, please create a node first");
            }
            return Ok(data);
        }
    }
}
