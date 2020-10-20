using System;
using System.Collections.Generic;
using System.Text;
using SmartIrrigation.Domain.WeatherStation;

namespace SmartIrrigation.Application.WeatherStation
{
    public class WeatherStationApplication :IWeatherStationApplication
    {
        private readonly IWeatherStationDomain _weatherStationDomain;

        public WeatherStationApplication(IWeatherStationDomain weatherStationDomain)
        {
            _weatherStationDomain = weatherStationDomain;
        }

        public string FindWeatherStation(string query) => _weatherStationDomain.FindWeatherStation(query);

    }
}
