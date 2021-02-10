using System;
using System.Collections.Generic;
using System.Text;
using SmartIrrigationModels.Models.Geocoding;

namespace SmartIrrigation.Domain.Node
{
    public interface INodeDomain
    {
        void AddNewNode(GeocodingAddressModelQueryParams address, bool isRealSensor, bool isSprinkler, bool isEnable, int? locationIdLocation, int idNearStation);
        SmartIrrigationModels.Models.DTOS.Node GetNodeByStreet(string street);
        SmartIrrigationModels.Models.DTOS.Node GetNodeByLatLong(string latitude, string longitude);
        IEnumerable<SmartIrrigationModels.Models.DTOS.Node> GetAllActiveNodes();
        void ActivateSprinkler(int idNode);
        void DectivateSprinkler(int idNode);
    }
}
