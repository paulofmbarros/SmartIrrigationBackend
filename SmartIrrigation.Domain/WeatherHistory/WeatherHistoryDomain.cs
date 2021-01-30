using System.Collections.Generic;
using DevMeteoStat;
using DevMeteoStat.WeatherStationsData;
using IpmaAPI;
using SmartIrrigation.Abstractions.Relational.Creates;
using SmartIrrigationModels.Models;
using SmartIrrigationModels.Models.DTOS;
using SmartIrrigationModels.Models.WeatherData;

namespace SmartIrrigation.Domain.WeatherHistory
{
    public class WeatherHistoryDomain : IWeatherHistoryDomain
    {
        private readonly IWeatherStationsData _weatherStationsData;
        private readonly IPointData _pointData;
        private readonly IIpmaDataRequisitions _ipmaDataRequisitions;
        private readonly IEvaporationRepository _evaporationRepository;
        private readonly IWeatherStationRepository _WeatherStationRepository;
        private readonly IReadHourlyRepository _readHourlyRepository;

        public WeatherHistoryDomain(IWeatherStationsData weatherStationsData, IPointData pointData, IIpmaDataRequisitions ipmaDataRequisitions, IEvaporationRepository evaporationRepository, IWeatherStationRepository weatherStationRepository, IReadHourlyRepository readHourlyRepository)
        {
            _weatherStationsData = weatherStationsData;
            _pointData = pointData;
            _ipmaDataRequisitions = ipmaDataRequisitions;
            _evaporationRepository = evaporationRepository;
            _WeatherStationRepository = weatherStationRepository;
            _readHourlyRepository = readHourlyRepository;
        }

        public RootWeatherDataModel<HourlyDataModel> GetHourlyDataOfStation(HourlyDataOfStationQueryParams hourlyDataOfStationParams) => _weatherStationsData.GetHourlyDataOfStation(hourlyDataOfStationParams);

        public RootWeatherDataModel<DailyDataModel> GetDailyDataOfStation(DailyDataOfStationQueryParams dailyDataOfStationParams) => _weatherStationsData.GetDailyDataOfStation(dailyDataOfStationParams);

        public RootWeatherDataModel<ClimateNormalsDataModel> GetClimateNormalsOfAStation(string stationId) => _weatherStationsData.GetClimateNormalsOfAStation(stationId);

        public RootWeatherDataModel<HourlyDataModel> GetHourlyDataOfPoint(HourlyDataOfAPointQueryParams hourlyDataOfAPointParams) => _pointData.GetHourlyDataOfPoint(hourlyDataOfAPointParams);

        public RootWeatherDataModel<HourlyDataModel> GetHourlyDataOfPoint(
            HourlyDataOfAPointQueryParams hourlyDataOfAPointParams, string stationName)
        {
            RootWeatherDataModel<HourlyDataModel> hourlyData = _pointData.GetHourlyDataOfPoint(hourlyDataOfAPointParams);
            return hourlyData;
        }

        public int AddHourlyDataOfPointToDatabase(
            RootWeatherDataModel<HourlyDataModel> hourlyData, string stationName, int idNode)
        {
            Station station = _WeatherStationRepository.GetWeatherStationFromDatabaseByStationName(stationName);
            return _readHourlyRepository.AddReadHourly(hourlyData, true, station.Id_Station, idNode);
        }

        public RootWeatherDataModel<DailyDataModel> DailyDataOfAPoint(DailyDataOfAPointQueryParams dailyDataOfAPointParams) => _pointData.DailyDataOfAPoint(dailyDataOfAPointParams);

        public RootWeatherDataModel<ClimateNormalsOfAPointDataModel> ClimateNormalsOfAPoint(float lat, float lon, int alt) => _pointData.ClimateNormalsOfAPoint(lat, lon, alt);

        public string[] GetHistoryEvaporationByCountyName(County county, string districtName) =>
            _ipmaDataRequisitions.GetHistoryEvaporationByCountyName(county, districtName);

        public int SaveEvaporationHistoryInDatabase(string[] lines, int Id_County) =>
            _evaporationRepository.InsertEvaporationData(lines, Id_County);

        public List<County> RetrieveCountiesThatHaveActiveNodes() =>
            _evaporationRepository.RetrieveCountiesThatHaveActiveNodes();


    }
}