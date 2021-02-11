using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using SmartIrrigation.Application.WeatherStation;
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
    public class NodeApplication : INodeApplication
    {
        private readonly IGeocodingDomain _geocodingDomain;
        private readonly ILocationDomain _locationDomain;
        private readonly INodeDomain _nodeDomain;
        private readonly IDistrictDomain _districtDomain;
        private readonly ICountiesDomain _countyDomain;
        private readonly IWeatherStationApplication _weatherStationApplication;

        public NodeApplication(IGeocodingDomain geocodingDomain, ILocationDomain locationDomain, INodeDomain nodeDomain,
            IDistrictDomain districtDomain, ICountiesDomain countyDomain,
            IWeatherStationApplication weatherStationApplication)
        {
            _geocodingDomain = geocodingDomain;
            _locationDomain = locationDomain;
            _nodeDomain = nodeDomain;
            _districtDomain = districtDomain;
            _countyDomain = countyDomain;
            _weatherStationApplication = weatherStationApplication;
        }

        public void AddNewNode(GeocodingAddressModelQueryParams address, bool isRealSensor, bool isSprinkler,
            bool isEnable, bool isLightOn, bool isSecurityCameraOn)
        {


            //TODO: REFACTOR THIS
            RootGeocodingDataModel<GeocodingAddressResponseModel> coords =
                _geocodingDomain.GetCoordsFromAddress(address);
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

            Station stationAdded =
                _weatherStationApplication.RetrieveStationByStationName(_weatherStationApplication
                    .AddWeatherStationToDatabase(address).Name);

            _nodeDomain.AddNewNode(address, isRealSensor, isSprinkler, isEnable, location.Id_Location,
                stationAdded.Id_Station ?? -1, isLightOn, isSecurityCameraOn);



        }

        public SmartIrrigationModels.Models.DTOS.Node GetNodeByStreet(string street) =>
            _nodeDomain.GetNodeByStreet(street);

        public SmartIrrigationModels.Models.DTOS.Node GetNodeByLatLong(string latitude, string longitude) =>
            _nodeDomain.GetNodeByLatLong(latitude, longitude);

        public List<SmartIrrigationModels.Models.DTOS.Node> GetAllActiveNodes() =>
            _nodeDomain.GetAllActiveNodes().ToList();

        public void ActivateSprinkler(int idNode) =>
            _nodeDomain.ActivateSprinkler(idNode);

        public void DeactivateSprinkler(int idNode) => _nodeDomain.DectivateSprinkler(idNode);
        public DashboardNodeData GetNodeDashboardDataById(int idNode) => _nodeDomain.GetNodeDashboardDataById(idNode);


    }
}
