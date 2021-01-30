using System;
using System.Collections.Generic;
using System.Text;
using SmartIrrigationModels.Models.Geocoding;

namespace SmartIrrigation.Application.BasicCRUD.Location
{
    public interface ILocationApplication
    {
        void SaveNewLocation(GeocodingAddressModelQueryParams parameters);
        SmartIrrigationModels.Models.DTOS.Location RetrieveLocation(string latitude, string longitude);
        SmartIrrigationModels.Models.DTOS.Location RetrieveLocationByNodeId(int nodeId);
    }
}
