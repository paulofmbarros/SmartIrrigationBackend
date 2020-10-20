using System;
using System.Collections.Generic;
using System.Text;
using DevMeteoStat.WeatherStationsData;

namespace SmartIrrigation.Domain.WeatherStation
{
   public class WeatherStationDomain :IWeatherStationDomain
   {
       private readonly IWeatherStationsData _weatherStationsData;

       public WeatherStationDomain(IWeatherStationsData weatherStationsData)
       {
           _weatherStationsData = weatherStationsData;
       }

       public string FindWeatherStation(string query) => _weatherStationsData.FindWeatherStation(query);

   }
}
