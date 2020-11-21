using System;
using System.Collections.Generic;
using System.Text;
using SmartIrrigationModels.Models;
using SmartIrrigationModels.Models.DTOS;
using SmartIrrigationModels.Models.Geocoding;

namespace SmartIrrigation.Abstractions.Relational.Creates
{
    public interface ILocationRepository
    {
        int InsertLocationData(RootGeocodingDataModel<GeocodingAddressResponseModel> data, int Id_District, int Id_County);
        int InsertLocationData(Location data, int Id_District, int Id_County);
        Location RetrieveLocationData(string latitude, string longitude);
        
    }
}
