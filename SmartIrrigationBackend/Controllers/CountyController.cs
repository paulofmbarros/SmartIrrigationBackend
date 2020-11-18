using Microsoft.AspNetCore.Mvc;
using SmartIrrigation.Application.BasicCRUD.Counties;
using SmartIrrigationModels.Models.DTOS;

namespace SmartIrrigationBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountyController : ControllerBase
    {
        private readonly ICountiesApplication _countiesApplication;

        public CountyController(ICountiesApplication countiesApplication)
        {
            _countiesApplication = countiesApplication;
        }

        [HttpGet("GetCountyByCountyName")]
        public IActionResult GetCountyByCountyName([FromQuery] string countyName)
        {
            County county = _countiesApplication.GetCountyByCountyName(countyName);
            return Ok(county);
        }
    }
}