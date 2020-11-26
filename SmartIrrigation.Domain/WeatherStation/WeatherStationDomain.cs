using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevMeteoStat;
using DevMeteoStat.WeatherStationsData;
using IpmaAPI;
using SmartIrrigation.Abstractions.Relational.Creates;
using SmartIrrigation.Abstractions.Relational.Reads;
using SmartIrrigationModels.Models;
using SmartIrrigationModels.Models.DTOS;
using SmartIrrigationModels.Models.NearByStation;
using SmartIrrigationModels.Models.WeatherData;
using SmartIrrigationModels.Models.WeatherStation;

namespace SmartIrrigation.Domain.WeatherStation
{
   public class WeatherStationDomain :IWeatherStationDomain
   {
       private readonly IWeatherStationsData _weatherStationsData;
       private readonly IWeatherStationRepository _weatherStationRepository;
       private readonly IReadStationInformation _readStationInformation;
     

       public WeatherStationDomain(IWeatherStationsData weatherStationsData,  IWeatherStationRepository weatherStationRepository, IReadStationInformation readStationInformation)
       {
           _weatherStationsData = weatherStationsData;
           _weatherStationRepository = weatherStationRepository;
           _readStationInformation = readStationInformation;
       }

       public RootWeatherStationModel<WeatherStationWithParamsModel> FindWeatherStation(string query, int? limit) => _weatherStationsData.FindWeatherStation(query, limit);
       public RootWeatherStationModel<NearbyWeatherStationModel> FindNearByStation(FindNearbyStationModel findStationParams) => _weatherStationsData.FindNearByStation(findStationParams);

       public void AddWeatherStationToDatabase(Station station) =>
           _weatherStationRepository.AddWeatherStationToDatabase(station);

       public WeatherStationWithParamsModel FindNearByStationFromLatLong(FindNearbyStationModel parameters)
       {
           NearbyWeatherStationModel nearbyStation = FindNearByStation(parameters).Data.FirstOrDefault();
           var weatherStationDetails = FindWeatherStation(nearbyStation.Name.En, 8).Data.FirstOrDefault();

           return weatherStationDetails;
       }

       public Station RetrieveStationByStationName(string stationName) =>
           _readStationInformation.RetrieveStationByStationName(stationName);

   }
}
