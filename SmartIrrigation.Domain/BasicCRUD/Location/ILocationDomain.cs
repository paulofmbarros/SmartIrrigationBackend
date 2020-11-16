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
    }
}
