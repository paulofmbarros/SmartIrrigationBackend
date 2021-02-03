using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SmartIrrigation.Application.WeatherHistory;
using SmartIrrigation.Application.WeatherStation;
using SmartIrrigationModels.Models;
using SmartIrrigationModels.Models.DTOS;
using SmartIrrigationModels.Models.Geocoding;
using SmartIrrigationModels.Models.NearByStation;
using SmartIrrigationModels.Models.WeatherData;
using SmartIrrigationModels.Models.WeatherStation;

namespace SmartIrrigationBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherHistoryController : ControllerBase
    {
        private readonly IWeatherHistoryApplication _weatherHistoryApplication;

        public WeatherHistoryController(IWeatherHistoryApplication weatherHistoryApplication)
        {
           
            _weatherHistoryApplication = weatherHistoryApplication;
        }

        
        /// <summary>
        /// Add a new Weather station to database
        /// </summary>
        /// <param name="findStationParams"></param>
        /// <returns></returns>
        [HttpGet("HourlyDataOfStation")]
        public IActionResult HourlyDataOfStation([FromQuery] HourlyDataOfStationQueryParams hourlyDataOfStationParams)
        {
            RootWeatherDataModel<HourlyDataModel> data = _weatherHistoryApplication.GetHourlyDataOfStation(hourlyDataOfStationParams);
            return Ok(data);
        }

        /// <summary>
        /// Add a new Weather station to database
        /// </summary>
        /// <param name="findStationParams"></param>
        /// <returns></returns>
        [HttpPost("SaveHourlyDataOfStationInDatabase")]
        public IActionResult SaveHourlyDataOfStationInDatabase(string latitude, string longitude)
        {
            int rowsAdded = _weatherHistoryApplication.SaveHourlyDataOfStationInDatabaseBasedOnCoords(latitude, longitude);
            return Ok(rowsAdded);
        }

        /// <summary>
        /// Add a new Weather station to database
        /// </summary>
        /// <param name="findStationParams"></param>
        /// <returns></returns>
        [HttpGet("HourlyDataOfPoint")]
        public IActionResult HourlyDataOfPoint([FromQuery] HourlyDataOfAPointQueryParams hourlyDataOfAPointParams)
        {
            RootWeatherDataModel<HourlyDataModel> data = _weatherHistoryApplication.GetHourlyDataOfPoint(hourlyDataOfAPointParams);
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
            RootWeatherDataModel<DailyDataModel> data = _weatherHistoryApplication.GetDailyDataOfStation(dailyDataOfStationParams);
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
            RootWeatherDataModel<DailyDataModel> data = _weatherHistoryApplication.DailyDataOfAPoint(dailyDataOfAPointParams);
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
            RootWeatherDataModel<ClimateNormalsDataModel> data = _weatherHistoryApplication.GetClimateNormalsOfAStation(stationId);
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
            RootWeatherDataModel<ClimateNormalsOfAPointDataModel> data = _weatherHistoryApplication.ClimateNormalsOfAPoint(lat, lon, alt);
            return Ok(data);
        }

        /// <summary>
        /// Add a new Weather station to database
        /// </summary>
        /// <param name="findStationParams"></param>
        /// <returns></returns>
        [HttpPost("RetrieveHistoryEvaporationByCountyName")]
        public IActionResult RetrieveHistoryEvaporationByCountyName(string countyName)
        {
            int rowsAffeted = _weatherHistoryApplication.GetHistoryEvaporationByCountyName(countyName);
            if (rowsAffeted == 0 || rowsAffeted == -1)
            {
                return NoContent();
            }
            else
            {
                return Ok($"{rowsAffeted} rows were affected");
            }
        }

        /// <summary>
        /// Add a new Weather station to database
        /// </summary>
        /// <param name="findStationParams"></param>
        /// <returns></returns>
        [HttpPost("UpdateHistoryEvaporationForAllActiveCounties")]
        public IActionResult UpdateHistoryEvaporationForAllActiveCounties()
        {
            _weatherHistoryApplication.UpdateHistoryEvaporationForAllActiveCounties();
            return Ok();
        }

        /// <summary>
        /// Add a new Weather station to database
        /// </summary>
        /// <param name="findStationParams"></param>
        /// <returns></returns>
        [HttpPost("UpdateWeatherConditionsForAllActiveNodes")]
        public IActionResult UpdateWeatherConditionsForAllActiveNodes()
        {
            _weatherHistoryApplication.UpdateWeatherConditionsForAllActiveNodes();
            return Ok();
        }


    
        [HttpGet("GetWeatherConditionsForAllActiveNodes")]
        public IActionResult GetWeatherConditionsForAllActiveNodes()
        {
             List<Read_Hourly> data = _weatherHistoryApplication.GetWeatherConditionsForAllActiveNodes();
             return Ok(data);
        }
    }
}