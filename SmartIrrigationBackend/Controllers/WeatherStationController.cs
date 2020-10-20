using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartIrrigation.Domain.WeatherStation;

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
        [HttpPost]
        public IActionResult AddStation([FromBody] object query)
        {
            _weatherStationDomain.FindWeatherStation("vancouver");
            return Ok();
        }
    }
}
