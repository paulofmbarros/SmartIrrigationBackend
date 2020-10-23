using System;
using System.Collections.Generic;
using System.Text;
using SmartIrrigationModels.Models;
using SmartIrrigationModels.Models.NearByStation;
using SmartIrrigationModels.Models.WeatherData;
using SmartIrrigationModels.Models.WeatherStation;

namespace DevMeteoStat.WeatherStationsData
{
   public interface IWeatherStationsData
   {
       RootWeatherStationModel<WeatherStationWithParamsModel> FindWeatherStation(string query, int? limit);
       RootWeatherStationModel<NearbyWeatherStationModel> FindNearByStation(FindNearbyStationModel findStationParams);
       RootWeatherDataModel<HourlyDataModel> GetHourlyDataOfStation(HourlyDataOfStationQueryParams hourlyDataOfStationParams);
       RootWeatherDataModel<DailyDataModel> GetDailyDataOfStation(DailyDataOfStationQueryParams dailyDataOfStationParams);
       RootWeatherDataModel<ClimateNormalsDataModel> GetClimateNormalsOfAStation(string stationId);
   }
}
