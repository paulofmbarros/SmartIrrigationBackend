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
       public RootWeatherDataModel<HourlyDataModel> GetHourlyDataOfStation(HourlyDataOfStationQueryParams hourlyDataOfStationParams) => _weatherStationsData.GetHourlyDataOfStation(hourlyDataOfStationParams);
       public RootWeatherDataModel<DailyDataModel> GetDailyDataOfStation(DailyDataOfStationQueryParams dailyDataOfStationParams)=> _weatherStationsData.GetDailyDataOfStation(dailyDataOfStationParams);
       public RootWeatherDataModel<ClimateNormalsDataModel> GetClimateNormalsOfAStation(string stationId)=> _weatherStationsData.GetClimateNormalsOfAStation(stationId);

       public RootWeatherDataModel<HourlyDataModel> GetHourlyDataOfPoint(
           HourlyDataOfAPointQueryParams hourlyDataOfAPointParams) =>
           _pointData.GetHourlyDataOfPoint(hourlyDataOfAPointParams);

       public RootWeatherDataModel<DailyDataModel> DailyDataOfAPoint(DailyDataOfAPointQueryParams dailyDataOfAPointParams)=> _pointData.DailyDataOfAPoint(dailyDataOfAPointParams);
       public RootWeatherDataModel<ClimateNormalsOfAPointDataModel> ClimateNormalsOfAPoint(float lat, float lon, int alt) => _pointData.ClimateNormalsOfAPoint(lat,lon,alt);

       public string[] GetHistoryEvaporationByCountyName(County county, string districtName) =>
           _ipmaDataRequisitions.GetHistoryEvaporationByCountyName(county, districtName);

       public int SaveEvaporationHistoryInDatabase(string[] lines, int Id_District) =>
           _evaporationRepository.InsertEvaporationData(lines, Id_District);


   }
}
