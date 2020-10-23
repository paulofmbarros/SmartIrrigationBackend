using System;
using System.Collections.Generic;
using System.Text;
using SmartIrrigationModels.Models.NearByStation;
using SmartIrrigationModels.Models.WeatherStation;

namespace SmartIrrigation.Application.WeatherStation
{
    public interface IWeatherStationApplication
    {
        string FindWeatherStation(string query, int? limit);

        RootWeatherStationModel FindNearByStation(FindNearbyStationModel findStationParams);
    }
}
