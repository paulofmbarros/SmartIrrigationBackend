using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Newtonsoft.Json.Linq;
using SmartIrrigation.Application.Node;
using SmartIrrigationModels.Models;
using SmartIrrigationModels.Models.DTOS;
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
        public IActionResult AddNewNode([FromBody] AddNewNodeQueryParams parameters)
        {
            _nodeApplication.AddNewNode(parameters);
            return Ok();
        }

        /// <summary>
        /// Add a new Weather station to database
        /// </summary>
        /// <param name="findStationParams"></param>
        /// <returns></returns>
        [HttpPost("GetNodeByStreet")]
        public IActionResult GetNodeByStreet(string street)
        {
           Node node = _nodeApplication.GetNodeByStreet(street);
            return Ok(node);
        }

        /// <summary>
        /// Add a new Weather station to database
        /// </summary>
        /// <param name="findStationParams"></param>
        /// <returns></returns>
        [HttpPost("GetNodeByLatLong")]
        public IActionResult GetNodeByLatLong(string latitude, string longitude)
        {
            Node node = _nodeApplication.GetNodeByLatLong(latitude, longitude);
            return Ok(node);
        }

        /// <summary>
        /// Add a new Weather station to database
        /// </summary>
        /// <param name="findStationParams"></param>
        /// <returns></returns>
        [HttpGet("GetAllActiveNodes")]
        public IActionResult GetAllActiveNodes()
        {
            List<Node> nodes = _nodeApplication.GetAllActiveNodes();
            return Ok(nodes);
        }

        /// <summary>
        /// Add a new Weather station to database
        /// </summary>
        /// <param name="findStationParams"></param>
        /// <returns></returns>
        [HttpPost("ActivateSprinkler")]
        public IActionResult ActivateSprinkler([FromBody] int idNode)
        {
            _nodeApplication.ActivateSprinkler(idNode);
            return Ok();
        }

        /// <summary>
        /// Add a new Weather station to database
        /// </summary>
        /// <param name="findStationParams"></param>
        /// <returns></returns>
        [HttpPost("DeactivateSprinkler")]
        public IActionResult DeactivateSprinkler([FromBody]int idNode)
        {
            _nodeApplication.DeactivateSprinkler(idNode);
            return Ok();
        }


        /// <summary>
        /// Add a new Weather station to database
        /// </summary>
        /// <param name="findStationParams"></param>
        /// <returns></returns>
        [HttpGet("GetNodeDashboardDataById")]
        public IActionResult GetNodeDashboardDataById([FromQuery] int idNode)
        {
            var data = _nodeApplication.GetNodeDashboardDataById(idNode);
            return Ok(data);
        }

        /// <summary>
        /// Add a new Weather station to database
        /// </summary>
        /// <param name="findStationParams"></param>
        /// <returns></returns>
        [HttpPost("TurnOnOrOfDevice")]
        public IActionResult TurnOnOrOfDevice(int idNode, string type, bool on)
        {
            var data = _nodeApplication.TurnOnOrOfDevice(idNode, type, on);
            return Ok(data);
        }


    }
}