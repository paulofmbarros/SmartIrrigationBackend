using System;
using System.Collections.Generic;
using System.Text;
using SmartIrrigationModels.Models;
using SmartIrrigationModels.Models.Geocoding;

namespace SmartIrrigation.Domain.Node
{
    public interface INodeDomain
    {
        SmartIrrigationModels.Models.DTOS.Node AddNewNode(AddNewNodeQueryParams parameters, int? locationIdLocation, int idNearStation);
        SmartIrrigationModels.Models.DTOS.Node GetNodeByStreet(string street);
        SmartIrrigationModels.Models.DTOS.Node GetNodeByLatLong(string latitude, string longitude);
        IEnumerable<SmartIrrigationModels.Models.DTOS.Node> GetAllActiveNodes();
        void ActivateSprinkler(int idNode);
        void DectivateSprinkler(int idNode);
        DashboardNodeData GetNodeDashboardDataById(int idNode);
        object TurnOnOrOfDevice(int idNode, string type, bool on);
    }
}
