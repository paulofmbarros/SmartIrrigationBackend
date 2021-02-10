using System;
using System.Collections.Generic;
using System.Text;
using SmartIrrigationModels.Models;
using SmartIrrigationModels.Models.DTOS;
using SmartIrrigationModels.Models.Geocoding;
using SmartIrrigationModels.Models.WeatherData;

namespace SmartIrrigation.Application.WeatherHistory
{
    public interface IWeatherHistoryApplication
    {
        RootWeatherDataModel<HourlyDataModel> GetHourlyDataOfStation(HourlyDataOfStationQueryParams hourlyDataOfStationParams);
        RootWeatherDataModel<DailyDataModel> GetDailyDataOfStation(DailyDataOfStationQueryParams dailyDataOfStationParams);
        RootWeatherDataModel<ClimateNormalsDataModel> GetClimateNormalsOfAStation(string stationId);
        RootWeatherDataModel<HourlyDataModel> GetHourlyDataOfPoint(HourlyDataOfAPointQueryParams hourlyDataOfAPointParams);
        RootWeatherDataModel<DailyDataModel> DailyDataOfAPoint(DailyDataOfAPointQueryParams dailyDataOfAPointParams);
        RootWeatherDataModel<ClimateNormalsOfAPointDataModel> ClimateNormalsOfAPoint(float lat, float lon, int alt);
        int GetHistoryEvaporationByCountyName(string countyName);
        void UpdateHistoryEvaporationForAllActiveCounties();
        public int SaveHourlyDataOfStationInDatabaseBasedOnCoords(string latitude, string longitude);
        void UpdateWeatherConditionsForAllActiveNodes();
        List<Read_Hourly> GetWeatherConditionsForAllActiveNodes();
        float GetMeanEvaportranspirationByIdNode(int idNode);
    }
}
