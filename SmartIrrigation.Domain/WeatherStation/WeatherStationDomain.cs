using System;
using System.Collections.Generic;
using System.Text;
using DevMeteoStat;
using DevMeteoStat.WeatherStationsData;
using IpmaAPI;
using SmartIrrigation.Abstractions.Relational.Creates;
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
       private readonly IPointData _pointData;
       private readonly IIpmaDataRequisitions _ipmaDataRequisitions;
       private readonly IEvaporationRepository _evaporationRepository;

       public WeatherStationDomain(IWeatherStationsData weatherStationsData, IPointData pointData, IIpmaDataRequisitions ipmaDataRequisitions, IEvaporationRepository evaporationRepository)
       {
           _weatherStationsData = weatherStationsData;
           _pointData = pointData;
           _ipmaDataRequisitions = ipmaDataRequisitions;
           _evaporationRepository = evaporationRepository;
       }

       public RootWeatherStationModel<WeatherStationWithParamsModel> FindWeatherStation(string query, int? limit) => _weatherStationsData.FindWeatherStation(query, limit);
       public RootWeatherStationModel<NearbyWeatherStationModel> FindNearByStation(FindNearbyStationModel findStationParams) => _weatherStationsData.FindNearByStation(findStationParams);
       


   }
}
