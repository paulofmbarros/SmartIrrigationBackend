using System;
using System.Collections.Generic;
using System.Text;
using SmartIrrigationModels.Models;
using SmartIrrigationModels.Models.Geocoding;

namespace SmartIrrigation.Domain.BasicCRUD.Location
{
     public interface ILocationDomain
    {
        int InsertLocationData(RootGeocodingDataModel<GeocodingAddressResponseModel> data, int Id_District, int Id_County);

        int InsertLocationData(SmartIrrigationModels.Models.DTOS.Location data, int Id_District, int Id_County);

        SmartIrrigationModels.Models.DTOS.Location RetrieveLocation(string latitude, string longitude);
    }
}
