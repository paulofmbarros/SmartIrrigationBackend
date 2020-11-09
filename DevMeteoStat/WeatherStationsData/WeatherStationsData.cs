using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using SmartIrrigationConfigurationService;
using SmartIrrigationModels.Models;
using SmartIrrigationModels.Models.NearByStation;
using SmartIrrigationModels.Models.WeatherData;
using SmartIrrigationModels.Models.WeatherStation;

namespace DevMeteoStat.WeatherStationsData
{
    public class WeatherStationsData : IWeatherStationsData
    {
        private readonly IConfig _config;

        public WeatherStationsData(IConfig config)
        {
            _config = config;
        }
        public RootWeatherStationModel<WeatherStationWithParamsModel> FindWeatherStation(string query, int? limit)
        {
            
            RestClient client = new RestClient($"{_config.GetConfiguration("DevMeteoStatApi:APIBASICURI")}stations/search");
            var request = new RestRequest();

            request.AddHeader("x-api-key", _config.GetConfiguration("DevMeteoStatApi:APIKEY"));
            request.AddHeader("Accept", "*/*");
            request.AddHeader("Accept-Encoding", "gzip, deflate");
            request.AddHeader("User-Agent", "runscope/0.1");
            request.Method = Method.GET;
            request.AddParameter("query", query);
            request.AddParameter("limit", limit);

            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<RootWeatherStationModel<WeatherStationWithParamsModel>>(response.Content);


        }

        public RootWeatherStationModel<NearbyWeatherStationModel> FindNearByStation(FindNearbyStationModel findNearbyStationModel)
        {

            RestClient client = new RestClient($"{_config.GetConfiguration("DevMeteoStatApi:APIBASICURI")}stations/nearby");
            var request = new RestRequest();
            request.AddHeader("x-api-key", _config.GetConfiguration("DevMeteoStatApi:APIKEY"));
            request.AddHeader("Accept-Encoding", "gzip, deflate");
            request.AddHeader("User-Agent", "runscope/0.1");
            request.AddHeader("Accept", "*/*");
            request.Method = Method.GET;
            request.AddParameter("lat",findNearbyStationModel.Latitude.ToString(System.Globalization.NumberFormatInfo.InvariantInfo),ParameterType.QueryString);
            request.AddParameter("lon", findNearbyStationModel.Longitude.ToString(System.Globalization.NumberFormatInfo.InvariantInfo), ParameterType.QueryString);
            request.AddParameter("limit", findNearbyStationModel.Limit, ParameterType.QueryString);
            request.RequestFormat = DataFormat.Json;


            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<RootWeatherStationModel<NearbyWeatherStationModel>>(response.Content);
       



        }

        public RootWeatherDataModel<HourlyDataModel> GetHourlyDataOfStation(HourlyDataOfStationQueryParams hourlyDataOfStationParams)
        {
            RestClient client = new RestClient($"{_config.GetConfiguration("DevMeteoStatApi:APIBASICURI")}stations/hourly");
            var request = new RestRequest();
            request.AddHeader("x-api-key", _config.GetConfiguration("DevMeteoStatApi:APIKEY"));
            request.AddHeader("Accept-Encoding", "gzip, deflate");
            request.AddHeader("User-Agent", "runscope/0.1");
            request.AddHeader("Accept", "*/*");
            request.Method = Method.GET;
            request.AddParameter("station", hourlyDataOfStationParams.Station, ParameterType.QueryString);
            request.AddParameter("start", hourlyDataOfStationParams.Start, ParameterType.QueryString);
            request.AddParameter("end", hourlyDataOfStationParams.End, ParameterType.QueryString);
            request.RequestFormat = DataFormat.Json;


            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<RootWeatherDataModel<HourlyDataModel>>(response.Content);
        }

        public RootWeatherDataModel<DailyDataModel> GetDailyDataOfStation(DailyDataOfStationQueryParams dailyDataOfStationParams)
        {
            RestClient client = new RestClient($"{_config.GetConfiguration("DevMeteoStatApi:APIBASICURI")}stations/daily");
            var request = new RestRequest();
            request.AddHeader("x-api-key", _config.GetConfiguration("DevMeteoStatApi:APIKEY"));
            request.AddHeader("Accept-Encoding", "gzip, deflate");
            request.AddHeader("User-Agent", "runscope/0.1");
            request.AddHeader("Accept", "*/*");
            request.Method = Method.GET;
            request.AddParameter("station", dailyDataOfStationParams.Station, ParameterType.QueryString);
            request.AddParameter("start", dailyDataOfStationParams.Start, ParameterType.QueryString);
            request.AddParameter("end", dailyDataOfStationParams.End, ParameterType.QueryString);
            request.RequestFormat = DataFormat.Json;


            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<RootWeatherDataModel<DailyDataModel>>(response.Content);
        }

        public RootWeatherDataModel<ClimateNormalsDataModel> GetClimateNormalsOfAStation(string stationId)
        {
            RestClient client = new RestClient($"{_config.GetConfiguration("DevMeteoStatApi:APIBASICURI")}stations/climate");
            var request = new RestRequest();
            request.AddHeader("x-api-key", _config.GetConfiguration("DevMeteoStatApi:APIKEY"));
            request.AddHeader("Accept-Encoding", "gzip, deflate");
            request.AddHeader("User-Agent", "runscope/0.1");
            request.AddHeader("Accept", "*/*");
            request.Method = Method.GET;
            request.AddParameter("station", stationId, ParameterType.QueryString);
            request.RequestFormat = DataFormat.Json;


            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<RootWeatherDataModel<ClimateNormalsDataModel>>(response.Content);
        }
    }
}
