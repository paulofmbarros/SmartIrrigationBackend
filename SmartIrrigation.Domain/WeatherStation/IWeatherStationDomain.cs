using System;
using System.Collections.Generic;
using System.Text;
using SmartIrrigationModels.Models;
using SmartIrrigationModels.Models.DTOS;
using SmartIrrigationModels.Models.NearByStation;
using SmartIrrigationModels.Models.WeatherData;
using SmartIrrigationModels.Models.WeatherStation;

namespace SmartIrrigation.Domain.WeatherStation
{
    public interface IWeatherStationDomain
    {
        RootWeatherStationModel<WeatherStationWithParamsModel> FindWeatherStation(string query, int? limit);

        RootWeatherStationModel<NearbyWeatherStationModel> FindNearByStation(FindNearbyStationModel findStationParams);

        void AddWeatherStationToDatabase(Station station);
        WeatherStationWithParamsModel FindNearByStationFromLatLong(FindNearbyStationModel findNearbyStationModel);
    }
}
