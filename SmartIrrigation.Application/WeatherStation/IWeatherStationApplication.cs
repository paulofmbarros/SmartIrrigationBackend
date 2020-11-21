using System;
using System.Collections.Generic;
using System.Text;
using SmartIrrigationModels.Models;
using SmartIrrigationModels.Models.DTOS;
using SmartIrrigationModels.Models.Geocoding;
using SmartIrrigationModels.Models.NearByStation;
using SmartIrrigationModels.Models.WeatherData;
using SmartIrrigationModels.Models.WeatherStation;

namespace SmartIrrigation.Application.WeatherStation
{
    public interface IWeatherStationApplication
    {
        RootWeatherStationModel<WeatherStationWithParamsModel> FindWeatherStation(string query, int? limit);

        RootWeatherStationModel<NearbyWeatherStationModel> FindNearByStation(FindNearbyStationModel findStationParams);

        void AddWeatherStationToDatabase(GeocodingAddressModelQueryParams station);
    }
}
