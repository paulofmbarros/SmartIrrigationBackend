﻿using System;
using System.Collections.Generic;
using System.Text;
using SmartIrrigation.Abstractions.Relational.Creates;
using SmartIrrigation.Abstractions.Relational.Reads;
using SmartIrrigationModels.Models;
using SmartIrrigationModels.Models.Geocoding;

namespace SmartIrrigation.Domain.Node
{
    public class NodeDomain :INodeDomain
    {
        private readonly INodeRepository _nodeRepository;
        private readonly IReadNodeInformation _nodeInformation;

        public NodeDomain(INodeRepository nodeRepository, IReadNodeInformation nodeInformation)
        {
            _nodeRepository = nodeRepository;
            _nodeInformation = nodeInformation;
        }

        public void AddNewNode(GeocodingAddressModelQueryParams address,  bool isRealSensor,  bool isSprinkler,
             bool isEnable, int? locationIdLocation, int IdNearStation, bool isLightOn, bool isSecurityCameraOn) =>
            _nodeRepository.AddNewNode(address, isRealSensor, isSprinkler, isEnable, locationIdLocation, IdNearStation,  isLightOn,  isSecurityCameraOn);

        public SmartIrrigationModels.Models.DTOS.Node GetNodeByStreet(string street) =>
            _nodeInformation.RetrieveNodeByStreet(street);

        public SmartIrrigationModels.Models.DTOS.Node GetNodeByLatLong(string latitude, string longitude) =>
            _nodeInformation.RetrieveNodeByLatLong(latitude, longitude);

        public IEnumerable<SmartIrrigationModels.Models.DTOS.Node> GetAllActiveNodes() => _nodeInformation.GetAllActiveNodes();

        public void ActivateSprinkler(int idNode) =>
            _nodeRepository.ActivateSprinkler(idNode);

        public void DectivateSprinkler(int idNode)=> _nodeRepository.DectivateSprinkler(idNode);
        public DashboardNodeData GetNodeDashboardDataById(int idNode) => _nodeRepository.GetNodeDashboardDataById(idNode);


    }
}
