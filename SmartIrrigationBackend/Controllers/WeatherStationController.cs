using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartIrrigation.Application.WeatherStation;
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
        [HttpPost("AddWeatherStationToDatabase")]
        public IActionResult AddWeatherStationToDatabase([FromBody] FindStationModel findStationParams)
        {
            RootWeatherStationModel<WeatherStationWithParamsModel> data = _weatherStationApplication.FindWeatherStation(findStationParams.Query, findStationParams.Limit);
            return Ok(data);
        }


        /// <summary>
        /// Add a new Weather station to database
        /// </summary>
        /// <param name="findStationParams"></param>
        /// <returns></returns>
        [HttpPost("AddWeatherStationToDatabase")]
        public IActionResult AddWeatherStationToDatabase([FromQuery] FindNearbyStationModel findStationParams)
        {
            RootWeatherStationModel<NearbyWeatherStationModel> data = _weatherStationApplication.FindNearByStation(findStationParams);
            return Ok(data);
        }
    }
}
