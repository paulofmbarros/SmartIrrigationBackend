using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartIrrigation.Application.Node;
using SmartIrrigationModels.Models.Geocoding;

namespace SmartIrrigationBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NodeController : ControllerBase
    {

        private readonly INodeApplication _nodeApplication;

        public NodeController(INodeApplication nodeApplication)
        {
            _nodeApplication = nodeApplication;
        }

        /// <summary>
        /// Add a new Weather station to database
        /// </summary>
        /// <param name="findStationParams"></param>
        /// <returns></returns>
        [HttpPost("AddNewNode")]
        public IActionResult AddNewNode(GeocodingAddressModelQueryParams address, bool isRealSensor, bool isSprinkler, bool isEnable=false)
        { 
            _nodeApplication.AddNewNode(address, isRealSensor,isSprinkler, isEnable);
            return Ok();
        }
    }
}
