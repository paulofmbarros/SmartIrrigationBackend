using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartIrrigation.Domain.WeatherStation;
using SmartIrrigationModels.Models;

namespace SmartIrrigationBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherStationController : ControllerBase
    {
        private readonly IWeatherStationDomain _weatherStationDomain;

        public WeatherStationController(IWeatherStationDomain weatherStationDomain)
        {
            _weatherStationDomain = weatherStationDomain;
        }
        /// <summary>
        /// Add a new Weather station to database
        /// </summary>
        /// <param name="findStationParams"></param>
        /// <returns></returns>
        [HttpPost("AddStation")]
        public IActionResult AddStation([FromBody] FindStationModel findStationParams)
        {
            _weatherStationDomain.FindWeatherStation(findStationParams.Query, findStationParams.Limit);
            return Ok();
        }

        /// <summary>
        /// Add a new Weather station to database
        /// </summary>
        /// <param name="findStationParams"></param>
        /// <returns></returns>
        [HttpPost("AddStation")]
        public IActionResult FindNearByStation([FromBody] FindNearbyStationModel findStationParams)
        {
            _weatherStationDomain.FindNearByStation(findStationParams);
            return Ok();
        }
    }
}
