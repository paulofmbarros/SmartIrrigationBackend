﻿using System;
using System.Collections.Generic;
using System.Text;
using SmartIrrigationModels.Models;
using SmartIrrigationModels.Models.Geocoding;

namespace SmartIrrigation.Application.Node
{
    public interface INodeApplication
    {
        void AddNewNode(GeocodingAddressModelQueryParams address, bool isRealSensor,  bool isSprinkler, bool isEnable,bool isLightOn, bool isSecurityCameraOn );
        SmartIrrigationModels.Models.DTOS.Node GetNodeByStreet(string street);
        SmartIrrigationModels.Models.DTOS.Node GetNodeByLatLong(string latitude, string longitude);
        List<SmartIrrigationModels.Models.DTOS.Node> GetAllActiveNodes();
        void ActivateSprinkler(int idNode);
        void DeactivateSprinkler(int idNode);
       DashboardNodeData GetNodeDashboardDataById(int idNode);
    }
}
