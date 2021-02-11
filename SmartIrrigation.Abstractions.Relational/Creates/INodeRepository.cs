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
        void AddNewNode(GeocodingAddressModelQueryParams address, bool isRealSensor, bool isSprinkler, bool isEnable,
            int? locationIdLocation, int IdNearStation, bool isLightOn, bool isSecurityCameraOn);

        void ActivateSprinkler(int idNode);
        void DectivateSprinkler(int idNode);
        DashboardNodeData GetNodeDashboardDataById(int idNode);
    }
}
