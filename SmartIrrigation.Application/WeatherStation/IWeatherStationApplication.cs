using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIrrigation.Application.WeatherStation
{
    public interface IWeatherStationApplication
    {
        string FindWeatherStation(string query);

    }
}
