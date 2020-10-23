using System;
using System.Collections.Generic;
using System.Text;
using SmartIrrigationModels.Models;
using SmartIrrigationModels.Models.NearByStation;
using SmartIrrigationModels.Models.WeatherStation;

namespace DevMeteoStat.WeatherStationsData
{
   public interface IWeatherStationsData
   {
       string FindWeatherStation(string query, int? limit);
       RootWeatherStationModel FindNearByStation(FindNearbyStationModel findStationParams);
   }
}
