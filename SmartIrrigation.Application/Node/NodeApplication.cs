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
using SmartIrrigation.Domain.Sensor;
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
        private readonly ISensorDomain _sensorDomain;
        private readonly IWeatherStationApplication _weatherStationApplication;

        public NodeApplication(IGeocodingDomain geocodingDomain, ILocationDomain locationDomain, INodeDomain nodeDomain,
            IDistrictDomain districtDomain, ICountiesDomain countyDomain,
            IWeatherStationApplication weatherStationApplication, ISensorDomain sensorDomain)
        {
            _geocodingDomain = geocodingDomain;
            _locationDomain = locationDomain;
            _nodeDomain = nodeDomain;
            _districtDomain = districtDomain;
            _countyDomain = countyDomain;
            _weatherStationApplication = weatherStationApplication;
            _sensorDomain = sensorDomain;
        }

        public void AddNewNode(AddNewNodeQueryParams parameters)
        {
            GeocodingAddressModelQueryParams address = new GeocodingAddressModelQueryParams(parameters.Street, parameters.DoorNumber, parameters.PostalCode, parameters.County, parameters.District);

            Station stationAdded=new Station();
            //TODO: REFACTOR THIS
            RootGeocodingDataModel<GeocodingAddressResponseModel> coords =
                _geocodingDomain.GetCoordsFromAddress(address);

            Location location = _locationDomain.RetrieveLocation(coords.Data.FirstOrDefault().Latitude,
                coords.Data.FirstOrDefault().Longitude);
            if (location == null)
            {
                District district = _districtDomain.GetDistrictByDistrictName(address.District);
                County county = _countyDomain.GetCountyByCountyName(address.County);
                _locationDomain.InsertLocationData(location, district.Id_District, county.CountyId);
                location = _locationDomain.RetrieveLocation(coords.Data.FirstOrDefault().Latitude,
                    coords.Data.FirstOrDefault().Longitude);

            }

            

            //SE nao for um sensor real procurar a estação metereologica mais proxima, adicionar a bd, e depois adiconar o no a apontar para a estação
            if (parameters.IsRealSensor != true)
            {
              
                var stationAddedInfo = _weatherStationApplication
                    .AddWeatherStationToDatabase(address);
                 stationAdded =
                    _weatherStationApplication.RetrieveStationByStationName(stationAddedInfo.station.Name);

                Location locationStationAddded = stationAddedInfo.locationStations;

               SmartIrrigationModels.Models.DTOS.Node nodeAdded =  _nodeDomain.AddNewNode(parameters, location.Id_Location,
                     stationAdded.Id_Station ?? -1);

                 _weatherStationApplication.AddWeatherStationDataToDatabase(stationAdded, locationStationAddded, nodeAdded);

            }
            else
            {
                //se for um sensor real, adiciona o no com o IdNearStation a -1 e depois adiciona os sensores a apontar para o no No

                _nodeDomain.AddNewNode(parameters, location.Id_Location, -1);

                foreach (var sensor in parameters.SensorsImplemented)
                {
                    _sensorDomain.AddNewSensor(parameters.Street, sensor, location.Id_Location ?? -1);
                }
            }
            


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

        public object TurnOnOrOfDevice(int idNode, string type, bool on) =>
            _nodeDomain.TurnOnOrOfDevice(idNode, type, on);
        
    }
}
