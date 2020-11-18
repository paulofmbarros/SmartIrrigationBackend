using System;
using System.Collections.Generic;
using System.Text;
using SmartIrrigation.Application.WeatherStation;
using SmartIrrigation.Domain.BasicCRUD.Counties;
using SmartIrrigation.Domain.BasicCRUD.District;
using SmartIrrigation.Domain.WeatherHistory;
using SmartIrrigation.Domain.WeatherStation;
using SmartIrrigationModels.Models;
using SmartIrrigationModels.Models.DTOS;
using SmartIrrigationModels.Models.WeatherData;

namespace SmartIrrigation.Application.WeatherHistory
{
    public class WeatherHistoryApplication :IWeatherHistoryApplication
    {
        private readonly IWeatherHistoryDomain _weatherHistoryDomain;
        private readonly ICountiesDomain _countiesDomain;
        private readonly IDistrictDomain _districtDomain;

        public WeatherHistoryApplication(IWeatherHistoryDomain weatherHistoryDomain, ICountiesDomain countiesDomain, IDistrictDomain districtDomain)
        {
            _weatherHistoryDomain = weatherHistoryDomain;
            _countiesDomain = countiesDomain;
            _districtDomain = districtDomain;
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
                int affectedrows = _weatherHistoryDomain.SaveEvaporationHistoryInDatabase(evaporationhistory, district.Id_District);
                return affectedrows;


            }

            return 0;
        }
    }
}
