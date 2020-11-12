using System;
using System.Collections.Generic;
using System.Text;
using SmartIrrigation.Domain.BasicCRUD.Counties;
using SmartIrrigation.Domain.BasicCRUD.District;
using SmartIrrigation.Domain.WeatherStation;
using SmartIrrigationModels.Models;
using SmartIrrigationModels.Models.DTOS;
using SmartIrrigationModels.Models.NearByStation;
using SmartIrrigationModels.Models.WeatherData;
using SmartIrrigationModels.Models.WeatherStation;

namespace SmartIrrigation.Application.WeatherStation
{
    public class WeatherStationApplication :IWeatherStationApplication
    {
        private readonly IWeatherStationDomain _weatherStationDomain;
        private readonly ICountiesDomain _countiesDomain;
        private readonly IDistrictDomain _districtDomain;

        public WeatherStationApplication(IWeatherStationDomain weatherStationDomain, ICountiesDomain countiesDomain, IDistrictDomain districtDomain)
        {
            _weatherStationDomain = weatherStationDomain;
            _countiesDomain = countiesDomain;
            _districtDomain = districtDomain;
        }

        public RootWeatherStationModel<WeatherStationWithParamsModel> FindWeatherStation(string query, int? limit) => _weatherStationDomain.FindWeatherStation(query, limit);

        public RootWeatherStationModel<NearbyWeatherStationModel> FindNearByStation(FindNearbyStationModel findStationParams) =>
            _weatherStationDomain.FindNearByStation(findStationParams);

        public RootWeatherDataModel<HourlyDataModel> GetHourlyDataOfStation(HourlyDataOfStationQueryParams hourlyDataOfStationParams) => _weatherStationDomain.GetHourlyDataOfStation(hourlyDataOfStationParams);
        public RootWeatherDataModel<DailyDataModel> GetDailyDataOfStation(DailyDataOfStationQueryParams dailyDataOfStationParams)=> _weatherStationDomain.GetDailyDataOfStation(dailyDataOfStationParams);
        public RootWeatherDataModel<ClimateNormalsDataModel> GetClimateNormalsOfAStation(string stationId)=> _weatherStationDomain.GetClimateNormalsOfAStation(stationId);

        public RootWeatherDataModel<HourlyDataModel> GetHourlyDataOfPoint(
            HourlyDataOfAPointQueryParams hourlyDataOfAPointParams) => _weatherStationDomain.GetHourlyDataOfPoint(hourlyDataOfAPointParams);

        public RootWeatherDataModel<DailyDataModel> DailyDataOfAPoint(DailyDataOfAPointQueryParams dailyDataOfAPointParams) => _weatherStationDomain.DailyDataOfAPoint(dailyDataOfAPointParams);
        public RootWeatherDataModel<ClimateNormalsOfAPointDataModel> ClimateNormalsOfAPoint(float lat, float lon, int alt)=> _weatherStationDomain.ClimateNormalsOfAPoint(lat, lon, alt);
        public object GetHistoryEvaporationByCountyName(string countyName)
        {
            County county = _countiesDomain.GetCountyByCountyName(countyName);
            string districtName = _districtDomain.RetrieveDistrictByCountyName(countyName).DistrictName;
            string[] evaporationhistory = _weatherStationDomain.GetHistoryEvaporationByCountyName(county, districtName);
            _weatherStationDomain.SaveEvaporationHistoryInDatabase(evaporationhistory);
            return evaporationhistory;
        }
    }
}
