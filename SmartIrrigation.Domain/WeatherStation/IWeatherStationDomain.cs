using System;
using System.Collections.Generic;
using System.Text;
using SmartIrrigationModels.Models;
using SmartIrrigationModels.Models.NearByStation;
using SmartIrrigationModels.Models.WeatherStation;

namespace SmartIrrigation.Domain.WeatherStation
{
    public interface IWeatherStationDomain
    {
        string FindWeatherStation(string query, int? limit);

        RootWeatherStationModel FindNearByStation(FindNearbyStationModel findStationParams);
    }
}
