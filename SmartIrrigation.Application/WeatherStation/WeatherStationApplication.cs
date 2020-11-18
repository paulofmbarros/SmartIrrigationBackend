using System;
using System.Collections.Generic;
using System.Text;
using SmartIrrigation.Domain.BasicCRUD.Counties;
using SmartIrrigation.Domain.BasicCRUD.District;
using SmartIrrigation.Domain.WeatherStation;
using SmartIrrigationModels.Models;
using SmartIrrigationModels.Models.DTOS;
using SmartIrrigationModels.Models.NearByStation;
using SmartIrrigationModels.Models.WeatherData;
using SmartIrrigationModels.Models.WeatherStation;

namespace SmartIrrigation.Application.WeatherStation
{
    public class WeatherStationApplication :IWeatherStationApplication
    {
        private readonly IWeatherStationDomain _weatherStationDomain;
        private readonly ICountiesDomain _countiesDomain;
        private readonly IDistrictDomain _districtDomain;

        public WeatherStationApplication(IWeatherStationDomain weatherStationDomain, ICountiesDomain countiesDomain, IDistrictDomain districtDomain)
        {
            _weatherStationDomain = weatherStationDomain;
            _countiesDomain = countiesDomain;
            _districtDomain = districtDomain;
        }

        public RootWeatherStationModel<WeatherStationWithParamsModel> FindWeatherStation(string query, int? limit) => _weatherStationDomain.FindWeatherStation(query, limit);

        public RootWeatherStationModel<NearbyWeatherStationModel> FindNearByStation(FindNearbyStationModel findStationParams) =>
            _weatherStationDomain.FindNearByStation(findStationParams);

        
    }
}
