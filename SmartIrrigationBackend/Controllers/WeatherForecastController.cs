﻿using Microsoft.AspNetCore.Mvc;
using SmartIrrigation.Application.WeatherForecast;

namespace SmartIrrigationBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastApplication _weatherForecastApplication;

        public WeatherForecastController(IWeatherForecastApplication weatherForecastApplication)
        {
            _weatherForecastApplication = weatherForecastApplication;
        }

        /// <summary>
        /// Add a new Weather station to database
        /// </summary>
        /// <param name="findStationParams"></param>
        /// <returns></returns>
        [HttpGet("GetWeatherForecast")]
        public IActionResult GetWeatherForecast([FromQuery] string latitude, string longitude)
        {
            var data = _weatherForecastApplication.GetWeatherForecast(latitude, longitude);
            return Ok(data);
        }
    }
}