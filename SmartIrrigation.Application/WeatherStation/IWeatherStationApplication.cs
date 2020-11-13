using System;
using System.Collections.Generic;
using System.Text;
using SmartIrrigationModels.Models;
using SmartIrrigationModels.Models.NearByStation;
using SmartIrrigationModels.Models.WeatherData;
using SmartIrrigationModels.Models.WeatherStation;

namespace SmartIrrigation.Application.WeatherStation
{
    public interface IWeatherStationApplication
    {
        RootWeatherStationModel<WeatherStationWithParamsModel> FindWeatherStation(string query, int? limit);

        RootWeatherStationModel<NearbyWeatherStationModel> FindNearByStation(FindNearbyStationModel findStationParams);
        RootWeatherDataModel<HourlyDataModel> GetHourlyDataOfStation(HourlyDataOfStationQueryParams hourlyDataOfStationParams);
        RootWeatherDataModel<DailyDataModel> GetDailyDataOfStation(DailyDataOfStationQueryParams dailyDataOfStationParams);
        RootWeatherDataModel<ClimateNormalsDataModel> GetClimateNormalsOfAStation(string stationId);
        RootWeatherDataModel<HourlyDataModel> GetHourlyDataOfPoint(HourlyDataOfAPointQueryParams hourlyDataOfAPointParams);
        RootWeatherDataModel<DailyDataModel> DailyDataOfAPoint(DailyDataOfAPointQueryParams dailyDataOfAPointParams);
        RootWeatherDataModel<ClimateNormalsOfAPointDataModel> ClimateNormalsOfAPoint( float lat,  float lon,  int alt);
        int GetHistoryEvaporationByCountyName(string countyName);
    }
}
