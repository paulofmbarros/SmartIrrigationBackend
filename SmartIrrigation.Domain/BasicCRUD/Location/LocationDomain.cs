using System;
using System.Collections.Generic;
using System.Text;
using SmartIrrigation.Abstractions.Relational.Creates;
using SmartIrrigationModels.Models;
using SmartIrrigationModels.Models.Geocoding;

namespace SmartIrrigation.Domain.BasicCRUD.Location
{
    public class LocationDomain:ILocationDomain
    {
        private readonly ILocationRepository _locationRepository;

        public LocationDomain(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public int InsertLocationData(RootGeocodingDataModel<GeocodingAddressResponseModel> data, int Id_District, int Id_County) =>
            _locationRepository.InsertLocationData(data, Id_District, Id_County);


    }
}
