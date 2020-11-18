using Microsoft.AspNetCore.Mvc;
using SmartIrrigation.Application.BasicCRUD.Districts;
using SmartIrrigationModels.Models.DTOS;

namespace SmartIrrigationBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly IDistrictApplication _districtApplication;

        public DistrictController(IDistrictApplication countiesApplication)
        {
            _districtApplication = countiesApplication;
        }

        [HttpGet("GetDistrictByDistrictName")]
        public IActionResult GetDistrictByDistrictName([FromQuery] string districtName)
        {
            District district = _districtApplication.GetDistrictByDistrictName(districtName);
            return Ok(district);
        }

        [HttpGet("GetDistrictByCountyName")]
        public IActionResult GetDistrictByCountyName([FromQuery] string countyName)
        {
            District district = _districtApplication.RetrieveDistrictByCountyName(countyName);
            return Ok(district);
        }
    }
}