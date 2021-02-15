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

        (Station station, Location locationStations) AddWeatherStationToDatabase(GeocodingAddressModelQueryParams station);
        void AddWeatherStationDataToDatabase(Station stationAdded, Location locationStation, SmartIrrigationModels.Models.DTOS.Node idNode);

        Station RetrieveStationByStationName(string stationName);
    }
}
