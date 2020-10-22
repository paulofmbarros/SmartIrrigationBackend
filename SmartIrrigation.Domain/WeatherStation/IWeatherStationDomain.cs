using System;
using System.Collections.Generic;
using System.Text;
using SmartIrrigationModels.Models;

namespace SmartIrrigation.Domain.WeatherStation
{
    public interface IWeatherStationDomain
    {
        string FindWeatherStation(string query, int? limit);

        void FindNearByStation(FindNearbyStationModel findStationParams);
    }
}
