using System;
using System.Collections.Generic;
using System.Text;
using DevMeteoStat.WeatherStationsData;
using SmartIrrigationModels.Models;
using SmartIrrigationModels.Models.NearByStation;

namespace SmartIrrigation.Domain.WeatherStation
{
   public class WeatherStationDomain :IWeatherStationDomain
   {
       private readonly IWeatherStationsData _weatherStationsData;

       public WeatherStationDomain(IWeatherStationsData weatherStationsData)
       {
           _weatherStationsData = weatherStationsData;
       }

       public string FindWeatherStation(string query, int? limit) => _weatherStationsData.FindWeatherStation(query, limit);
       public void FindNearByStation(FindNearbyStationModel findStationParams) => _weatherStationsData.FindNearByStation(findStationParams);
       
   }
}
