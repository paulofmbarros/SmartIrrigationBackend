using System;
using System.Collections.Generic;
using System.Text;
using SmartIrrigationModels.Models;
using SmartIrrigationModels.Models.DTOS;
using SmartIrrigationModels.Models.Geocoding;

namespace SmartIrrigation.Abstractions.Relational.Creates
{
    public interface INodeRepository
    {
        void AddNewNode(AddNewNodeQueryParams parameters, int? locationIdLocation, int idNearStation);

        void ActivateSprinkler(int idNode);
        void DectivateSprinkler(int idNode);
        DashboardNodeData GetNodeDashboardDataById(int idNode);
        object TurnOnOrOfDevice(int idNode, string type,  bool on);
    }
}
