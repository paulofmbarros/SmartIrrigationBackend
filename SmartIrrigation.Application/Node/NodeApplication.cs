using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using SmartIrrigation.Domain;
using SmartIrrigation.Domain.BasicCRUD.Counties;
using SmartIrrigation.Domain.BasicCRUD.District;
using SmartIrrigation.Domain.BasicCRUD.Location;
using SmartIrrigation.Domain.Geocoding;
using SmartIrrigation.Domain.Node;
using SmartIrrigation.Domain.WeatherStation;
using SmartIrrigationModels.Models;
using SmartIrrigationModels.Models.DTOS;
using SmartIrrigationModels.Models.Geocoding;
using SmartIrrigationModels.Models.NearByStation;
using SmartIrrigationModels.Models.WeatherStation;

namespace SmartIrrigation.Application.Node
{
    public class NodeApplication :INodeApplication
    {
        private readonly IGeocodingDomain _geocodingDomain;
        private readonly ILocationDomain _locationDomain;
        private readonly INodeDomain _nodeDomain;
        private readonly IDistrictDomain _districtDomain;
        private readonly ICountiesDomain _countyDomain;
        private readonly IWeatherStationDomain _weatherStationDomain;

        public NodeApplication(GeocodingDomain geocodingDomain, LocationDomain locationDomain, NodeDomain nodeDomain, DistrictDomain districtDomain, CountiesDomain countyDomain, IWeatherStationDomain weatherStationDomain)
        {
            _geocodingDomain = geocodingDomain;
            _locationDomain = locationDomain;
            _nodeDomain = nodeDomain;
            _districtDomain = districtDomain;
            _countyDomain = countyDomain;
            _weatherStationDomain = weatherStationDomain;
        }

        public object AddNewNode(GeocodingAddressModelQueryParams address, bool isRealSensor, bool isSprinkler,
             bool isEnable)
        {
            RootGeocodingDataModel<GeocodingAddressResponseModel> coords =_geocodingDomain.GetCoordsFromAddress(address);
            Location location = _locationDomain.RetrieveLocation(coords.Data.FirstOrDefault().Latitude,
                coords.Data.FirstOrDefault().Longitude);
            if (location == null)
            {
                District district = _districtDomain.GetDistrictByDistrictName(address.District);
                County county = _countyDomain.GetCountyByCountyName(address.County);
                _locationDomain.InsertLocationData(coords, district.Id_District, county.CountyId);
                location = _locationDomain.RetrieveLocation(coords.Data.FirstOrDefault().Latitude,
                    coords.Data.FirstOrDefault().Longitude);
                
            } 
            
            FindNearbyStationModel paraModel=new FindNearbyStationModel(float.Parse(location.Latitude,CultureInfo.InvariantCulture.NumberFormat), float.Parse(location.Longitude, CultureInfo.InvariantCulture.NumberFormat),null,null);
            RootWeatherStationModel<NearbyWeatherStationModel> nearStation = _weatherStationDomain.FindNearByStation(paraModel);

            //add node;
            _nodeDomain.AddNewNode(address, isRealSensor, isSprinkler, isEnable, location.Id_Location, nearStation.Data.FirstOrDefault().Id);

        }
    }

    
}
