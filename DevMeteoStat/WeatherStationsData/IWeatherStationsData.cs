using System;
using System.Collections.Generic;
using System.Text;

namespace DevMeteoStat.WeatherStationsData
{
   public interface IWeatherStationsData
   {
       string FindWeatherStation(string query);
   }
}
