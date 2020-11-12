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
using SmartIrrigationModels.Models.WeatherData;
using SmartIrrigationModels.Models.WeatherStation;

namespace SmartIrrigationBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherHistoryController : ControllerBase
    {
        private readonly IWeatherStationApplication _weatherStationApplication;

        public WeatherHistoryController(IWeatherStationApplication weatherStationApplication)
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
            RootWeatherStationModel<WeatherStationWithParamsModel> data = _weatherStationApplication.FindWeatherStation(findStationParams.Query, findStationParams.Limit);
            return Ok(data);
        }

        /// <summary>
        /// Add a new Weather station to database
        /// </summary>
        /// <param name="findStationParams"></param>
        /// <returns></returns>
        [HttpGet("FindNearByStation")]
        public IActionResult FindNearByStation([FromQuery] FindNearbyStationModel findStationParams)
        {
            RootWeatherStationModel<NearbyWeatherStationModel> data = _weatherStationApplication.FindNearByStation(findStationParams);
            return Ok(data);
        }

        /// <summary>
        /// Add a new Weather station to database
        /// </summary>
        /// <param name="findStationParams"></param>
        /// <returns></returns>
        [HttpGet("HourlyDataOfStation")]
        public IActionResult HourlyDataOfStation([FromQuery] HourlyDataOfStationQueryParams hourlyDataOfStationParams)
        {
            RootWeatherDataModel<HourlyDataModel> data = _weatherStationApplication.GetHourlyDataOfStation(hourlyDataOfStationParams);
            return Ok(data);
        }
        /// <summary>
        /// Add a new Weather station to database
        /// </summary>
        /// <param name="findStationParams"></param>
        /// <returns></returns>
        [HttpGet("HourlyDataOfPoint")]
        public IActionResult HourlyDataOfPoint([FromQuery] HourlyDataOfAPointQueryParams hourlyDataOfAPointParams)
        {
            RootWeatherDataModel<HourlyDataModel> data = _weatherStationApplication.GetHourlyDataOfPoint(hourlyDataOfAPointParams);
            return Ok(data);
        }
        /// <summary>
        /// Add a new Weather station to database
        /// </summary>
        /// <param name="findStationParams"></param>
        /// <returns></returns>
        [HttpGet("DailyDataOfStation")]
        public IActionResult DailyDataOfStation([FromQuery] DailyDataOfStationQueryParams dailyDataOfStationParams)
        {
            RootWeatherDataModel<DailyDataModel> data = _weatherStationApplication.GetDailyDataOfStation(dailyDataOfStationParams);
            return Ok(data);
        }
        /// <summary>
        /// Add a new Weather station to database
        /// </summary>
        /// <param name="findStationParams"></param>
        /// <returns></returns>
        [HttpGet("DailyDataOfAPoint")]
        public IActionResult DailyDataOfAPoint([FromQuery] DailyDataOfAPointQueryParams dailyDataOfAPointParams)
        {
            RootWeatherDataModel<DailyDataModel> data = _weatherStationApplication.DailyDataOfAPoint(dailyDataOfAPointParams);
            return Ok(data);
        }
        /// <summary>
        /// Add a new Weather station to database
        /// </summary>
        /// <param name="findStationParams"></param>
        /// <returns></returns>
        [HttpGet("ClimateNormalsOfAStation")]
        public IActionResult ClimateNormalsOfAStation([FromQuery] string stationId)
        {
            RootWeatherDataModel<ClimateNormalsDataModel> data = _weatherStationApplication.GetClimateNormalsOfAStation(stationId);
            return Ok(data);
        }
        /// <summary>
        /// Add a new Weather station to database
        /// </summary>
        /// <param name="findStationParams"></param>
        /// <returns></returns>
        [HttpGet("ClimateNormalsOfAPoint")]
        public IActionResult ClimateNormalsOfAPoint(float lat, float lon, int alt)
        {
            RootWeatherDataModel<ClimateNormalsOfAPointDataModel> data = _weatherStationApplication.ClimateNormalsOfAPoint(lat,lon,alt);
            return Ok(data);
        }

        /// <summary>
        /// Add a new Weather station to database
        /// </summary>
        /// <param name="findStationParams"></param>
        /// <returns></returns>
        [HttpGet("GetHistoryEvaporationByCountyName")]
        public IActionResult GetHistoryEvaporationByCountyName(string countyName)
        {
            var data = _weatherStationApplication.GetHistoryEvaporationByCountyName(countyName);
            return Ok(data);
        }
    }
}
