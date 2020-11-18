using Microsoft.AspNetCore.Mvc;
using SmartIrrigation.Application.WeatherHistory;
using SmartIrrigation.Application.WeatherStation;
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
        private readonly IWeatherHistoryApplication _weatherHistoryApplication;

        public WeatherHistoryController(IWeatherStationApplication weatherStationApplication, IWeatherHistoryApplication weatherHistoryApplication)
        {
            _weatherStationApplication = weatherStationApplication;
            _weatherHistoryApplication = weatherHistoryApplication;
        }

        /// <summary>
        /// Add a new Weather station to database
        /// </summary>
        /// <param name="findStationParams"></param>
        /// <returns></returns>
        [HttpPost("FindWeatherStation")]
        public IActionResult FindWeatherStation([FromBody] FindStationModel findStationParams)
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
            RootWeatherDataModel<HourlyDataModel> data = _weatherHistoryApplication.GetHourlyDataOfStation(hourlyDataOfStationParams);
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
    }
}