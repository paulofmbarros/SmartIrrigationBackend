using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using SmartIrrigation.Application.WeatherStation;
using SmartIrrigation.Domain.BasicCRUD.Counties;
using SmartIrrigation.Domain.BasicCRUD.District;
using SmartIrrigation.Domain.BasicCRUD.Location;
using SmartIrrigation.Domain.Geocoding;
using SmartIrrigation.Domain.Node;
using SmartIrrigation.Domain.WeatherHistory;
using SmartIrrigation.Domain.WeatherStation;
using SmartIrrigationModels.Models;
using SmartIrrigationModels.Models.DTOS;
using SmartIrrigationModels.Models.Geocoding;
using SmartIrrigationModels.Models.NearByStation;
using SmartIrrigationModels.Models.WeatherData;

namespace SmartIrrigation.Application.WeatherHistory
{
    public class WeatherHistoryApplication :IWeatherHistoryApplication
    {
        private readonly IWeatherHistoryDomain _weatherHistoryDomain;
        private readonly ICountiesDomain _countiesDomain;
        private readonly IDistrictDomain _districtDomain;
        private readonly IGeocodingDomain _geocodingDomain;
        private readonly ILocationDomain _locationDomain;
        private readonly IWeatherStationDomain _weatherStationDomain;
        private readonly INodeDomain _nodeDomain;

        public WeatherHistoryApplication(IWeatherHistoryDomain weatherHistoryDomain, ICountiesDomain countiesDomain, IDistrictDomain districtDomain, IGeocodingDomain geocodingDomain, ILocationDomain locationDomain, IWeatherStationDomain weatherStationDomain, INodeDomain nodeDomain)
        {
            _weatherHistoryDomain = weatherHistoryDomain;
            _countiesDomain = countiesDomain;
            _districtDomain = districtDomain;
            _geocodingDomain = geocodingDomain;
            _locationDomain = locationDomain;
            _weatherStationDomain = weatherStationDomain;
            _nodeDomain = nodeDomain;
        }
        public RootWeatherDataModel<HourlyDataModel> GetHourlyDataOfStation(HourlyDataOfStationQueryParams hourlyDataOfStationParams) => _weatherHistoryDomain.GetHourlyDataOfStation(hourlyDataOfStationParams);
        public RootWeatherDataModel<DailyDataModel> GetDailyDataOfStation(DailyDataOfStationQueryParams dailyDataOfStationParams) => _weatherHistoryDomain.GetDailyDataOfStation(dailyDataOfStationParams);
        public RootWeatherDataModel<ClimateNormalsDataModel> GetClimateNormalsOfAStation(string stationId) => _weatherHistoryDomain.GetClimateNormalsOfAStation(stationId);

        public RootWeatherDataModel<HourlyDataModel> GetHourlyDataOfPoint(
            HourlyDataOfAPointQueryParams hourlyDataOfAPointParams) => _weatherHistoryDomain.GetHourlyDataOfPoint(hourlyDataOfAPointParams);

        public RootWeatherDataModel<DailyDataModel> DailyDataOfAPoint(DailyDataOfAPointQueryParams dailyDataOfAPointParams) => _weatherHistoryDomain.DailyDataOfAPoint(dailyDataOfAPointParams);
        public RootWeatherDataModel<ClimateNormalsOfAPointDataModel> ClimateNormalsOfAPoint(float lat, float lon, int alt) => _weatherHistoryDomain.ClimateNormalsOfAPoint(lat, lon, alt);
        public int GetHistoryEvaporationByCountyName(string countyName)
        {
            County county = _countiesDomain.GetCountyByCountyName(countyName);

            if (county != null)
            {
                District district = _districtDomain.RetrieveDistrictByCountyName(countyName);
                string[] evaporationhistory = _weatherHistoryDomain.GetHistoryEvaporationByCountyName(county, district.DistrictName);
                if (evaporationhistory.Length == 0)
                {
                    return -1;
                }
                int affectedrows = _weatherHistoryDomain.SaveEvaporationHistoryInDatabase(evaporationhistory, county.CountyId);
                return affectedrows;


            }

            return 0;
        }

        public void UpdateHistoryEvaporationForAllActiveCounties()
        {
            List <County> listOfCounties = _weatherHistoryDomain.RetrieveCountiesThatHaveActiveNodes();
            foreach (var county in listOfCounties.Distinct())
            {
                GetHistoryEvaporationByCountyName(county.Name);
            }
        }

        public int SaveHourlyDataOfStationInDatabaseBasedOnCoords(string latitude, string longitude)
        {
            
            WeatherStationWithParamsModel nearbyWeatherStation =
                _weatherStationDomain.FindNearByStationFromLatLong(new FindNearbyStationModel(float.Parse(latitude, CultureInfo.InvariantCulture.NumberFormat),
                    float.Parse(longitude, CultureInfo.InvariantCulture.NumberFormat), 8, null));



            HourlyDataOfAPointQueryParams data = new HourlyDataOfAPointQueryParams(
                float.Parse(latitude, CultureInfo.InvariantCulture.NumberFormat), float.Parse(longitude, CultureInfo.InvariantCulture.NumberFormat), null,
                DateTime.Now.AddDays(-9).ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd"), null);
           var hourlyData = _weatherHistoryDomain.GetHourlyDataOfPoint(data, nearbyWeatherStation.Name.En);
           SmartIrrigationModels.Models.DTOS.Node node = _nodeDomain.GetNodeByLatLong(latitude, longitude);
           return _weatherHistoryDomain.AddHourlyDataOfPointToDatabase(hourlyData, nearbyWeatherStation.Name.En, node.IdNode);

        }

        public void UpdateWeatherConditionsForAllActiveNodes()
        {
            //first get all active nodes

            List<SmartIrrigationModels.Models.DTOS.Node> activeNodes = _nodeDomain.GetAllActiveNodes().ToList();

            foreach (var node in activeNodes)
            {
                Location loc = _locationDomain.RetrieveLocationByNodeId(node.IdNode);
                SaveHourlyDataOfStationInDatabaseBasedOnCoords(loc.Latitude, loc.Longitude);
            }
        }

        public List<Read_Hourly> GetWeatherConditionsForAllActiveNodes()
        {
            return _weatherHistoryDomain.GetWeatherConditionsForAllActiveNodes();
        }

        public float GetMeanEvaportranspirationByIdNode(int idNode) =>
            _weatherHistoryDomain.GetMeanEvaportranspirationByIdNode(idNode);


    }
}
