using System;
using System.Collections.Generic;
using System.Text;
using SmartIrrigationModels.Models;

namespace DevMeteoStat.WeatherStationsData
{
   public interface IWeatherStationsData
   {
       string FindWeatherStation(string query, int? limit);
       void FindNearByStation(FindNearbyStationModel findStationParams);
   }
}
