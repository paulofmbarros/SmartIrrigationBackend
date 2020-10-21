using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIrrigation.Domain.WeatherStation
{
    public interface IWeatherStationDomain
    {
        string FindWeatherStation(string query, int? limit);

    }
}
