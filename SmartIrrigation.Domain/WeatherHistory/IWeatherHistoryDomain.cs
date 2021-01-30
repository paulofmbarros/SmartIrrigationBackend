using System;
using System.Collections.Generic;
using System.Text;
using SmartIrrigationModels.Models;
using SmartIrrigationModels.Models.DTOS;
using SmartIrrigationModels.Models.WeatherData;

namespace SmartIrrigation.Domain.WeatherHistory
{
    public interface IWeatherHistoryDomain
    {
        RootWeatherDataModel<HourlyDataModel> GetHourlyDataOfStation(HourlyDataOfStationQueryParams hourlyDataOfStationParams);
        RootWeatherDataModel<DailyDataModel> GetDailyDataOfStation(DailyDataOfStationQueryParams dailyDataOfStationParams);
        RootWeatherDataModel<ClimateNormalsDataModel> GetClimateNormalsOfAStation(string stationId);
        RootWeatherDataModel<HourlyDataModel> GetHourlyDataOfPoint(HourlyDataOfAPointQueryParams hourlyDataOfAPointParams);
        RootWeatherDataModel<HourlyDataModel> GetHourlyDataOfPoint(HourlyDataOfAPointQueryParams hourlyDataOfAPointParams, string stationName);
        RootWeatherDataModel<DailyDataModel> DailyDataOfAPoint(DailyDataOfAPointQueryParams dailyDataOfAPointParams);
        RootWeatherDataModel<ClimateNormalsOfAPointDataModel> ClimateNormalsOfAPoint(float lat, float lon, int alt);
        string[] GetHistoryEvaporationByCountyName(County county, string districtName);

        int SaveEvaporationHistoryInDatabase(string[] lines, int Id_County);
        List<County> RetrieveCountiesThatHaveActiveNodes();
        int AddHourlyDataOfPointToDatabase(RootWeatherDataModel<HourlyDataModel> hourlyData, string nameEn, int idNode);
    }
}
