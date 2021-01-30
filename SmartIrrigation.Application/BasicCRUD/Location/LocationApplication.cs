using System;
using System.Collections.Generic;
using System.Text;
using SmartIrrigation.Domain.BasicCRUD.Counties;
using SmartIrrigation.Domain.BasicCRUD.District;
using SmartIrrigation.Domain.BasicCRUD.Location;
using SmartIrrigation.Domain.Geocoding;
using SmartIrrigationModels.Models;
using SmartIrrigationModels.Models.DTOS;
using SmartIrrigationModels.Models.Geocoding;

namespace SmartIrrigation.Application.BasicCRUD.Location
{
    public class LocationApplication : ILocationApplication
    {
        private readonly IGeocodingDomain _geocodingDomain;
        private readonly ILocationDomain _locationDomain;
        private readonly ICountiesDomain _countiesDomain;
        private readonly IDistrictDomain _districtDomain;

        public LocationApplication(IGeocodingDomain geocodingDomain, ILocationDomain locationDomain,
            ICountiesDomain countiesDomain, IDistrictDomain districtDomain)
        {
            _geocodingDomain = geocodingDomain;
            _locationDomain = locationDomain;
            _countiesDomain = countiesDomain;
            _districtDomain = districtDomain;
        }

        public void SaveNewLocation(GeocodingAddressModelQueryParams parameters)
        {
            //get data from API
            RootGeocodingDataModel<GeocodingAddressResponseModel> data =
                _geocodingDomain.GetCoordsFromAddress(parameters);

            County county = _countiesDomain.GetCountyByCountyName(parameters.County);

            if (county != null)
            {
                District district = _districtDomain.RetrieveDistrictByCountyName(parameters.County);

                //save in database

                int affectedRows = _locationDomain.InsertLocationData(data, district.Id_District, county.CountyId);
            }
        }

        public SmartIrrigationModels.Models.DTOS.Location RetrieveLocation(string latitude, string longitude) =>
            _locationDomain.RetrieveLocation(latitude, longitude);

        public SmartIrrigationModels.Models.DTOS.Location RetrieveLocationByNodeId(int nodeId) =>
            _locationDomain.RetrieveLocationByNodeId(nodeId);


    }
}

   
