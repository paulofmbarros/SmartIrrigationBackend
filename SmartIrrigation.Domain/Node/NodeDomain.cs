using System;
using System.Collections.Generic;
using System.Text;
using SmartIrrigation.Abstractions.Relational.Creates;
using SmartIrrigationModels.Models.Geocoding;

namespace SmartIrrigation.Domain.Node
{
    public class NodeDomain :INodeDomain
    {
        private readonly INodeRepository _nodeRepository;

        public NodeDomain(INodeRepository nodeRepository)
        {
            _nodeRepository = nodeRepository;
        }

        public void AddNewNode(GeocodingAddressModelQueryParams address,  bool isRealSensor,  bool isSprinkler,
             bool isEnable, int locationIdLocation, int IdNearStation) =>
            _nodeRepository.AddNewNode(address, isRealSensor, isSprinkler, isEnable, locationIdLocation, IdNearStation);

    }
}
