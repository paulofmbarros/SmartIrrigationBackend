using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartIrrigation.Application.WeatherStation;
using SmartIrrigation.Domain.WeatherStation;
using SmartIrrigationModels.Models;
using SmartIrrigationModels.Models.NearByStation;
using SmartIrrigationModels.Models.WeatherStation;

namespace SmartIrrigationBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherStationController : ControllerBase
    {
        private readonly IWeatherStationApplication _weatherStationApplication;

        public WeatherStationController(IWeatherStationApplication weatherStationApplication)
        {
            _weatherStationApplication = weatherStationApplication;
        }
        /// <summary>
        /// Add a new Weather station to database
        /// </summary>
        /// <param name="findStationParams"></param>
        /// <returns></returns>
        [HttpPost("AddStation")]
        public IActionResult AddStation([FromBody] FindStationModel findStationParams)
        {
            _weatherStationApplication.FindWeatherStation(findStationParams.Query, findStationParams.Limit);
            return Ok();
        }

        /// <summary>
        /// Add a new Weather station to database
        /// </summary>
        /// <param name="findStationParams"></param>
        /// <returns></returns>
        [HttpGet("FindNearByStation")]
        public IActionResult FindNearByStation([FromQuery] FindNearbyStationModel findStationParams)
        {
            RootWeatherStationModel data = _weatherStationApplication.FindNearByStation(findStationParams);
            return Ok(data);
        }
    }
}
