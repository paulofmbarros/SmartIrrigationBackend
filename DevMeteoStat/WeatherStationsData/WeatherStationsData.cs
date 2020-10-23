using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using DevMeteoStat.Configuration;
using Newtonsoft.Json;
using RestSharp;
using SmartIrrigationModels.Models;
using SmartIrrigationModels.Models.NearByStation;
using SmartIrrigationModels.Models.WeatherStation;

namespace DevMeteoStat.WeatherStationsData
{
    public class WeatherStationsData : IWeatherStationsData
    {
        public string FindWeatherStation(string query, int? limit)
        {
            
            RestClient client = new RestClient($"{Config.GetConfiguration("APIBASICURI")}stations/search");
            var request = new RestRequest();

            request.AddHeader("x-api-key", Config.GetConfiguration("APIKEY"));
            request.AddHeader("Accept", "*/*");
            request.AddHeader("Accept-Encoding", "gzip, deflate");
            request.AddHeader("User-Agent", "runscope/0.1");
            request.Method = Method.GET;
            request.AddParameter("query", query);
            request.AddParameter("limit", limit);

            var response = client.Execute(request);
            var result = response.Content;
            
            return result;

        }

        public void FindNearByStation(FindNearbyStationModel findNearbyStationModel)
        {
            RestClient client = new RestClient($"{Config.GetConfiguration("APIBASICURI")}stations/nearby");
            var request = new RestRequest();
            List<NearbyWeatherStationModel> ListWeatherStations = new List<NearbyWeatherStationModel>();

            request.AddHeader("x-api-key", Config.GetConfiguration("APIKEY"));
            request.AddHeader("Accept-Encoding", "gzip, deflate");
            request.AddHeader("User-Agent", "runscope/0.1");
            request.AddHeader("Accept", "*/*");
            request.Method = Method.GET;
            request.AddParameter("lat",findNearbyStationModel.Latitude.ToString(System.Globalization.NumberFormatInfo.InvariantInfo),ParameterType.QueryString);
            request.AddParameter("lon", findNearbyStationModel.Longitude.ToString(System.Globalization.NumberFormatInfo.InvariantInfo), ParameterType.QueryString);
            request.AddParameter("limit", findNearbyStationModel.Limit, ParameterType.QueryString);
            request.RequestFormat = DataFormat.Json;


            var response = client.Execute(request);
            var x = JsonConvert.DeserializeObject<RootWeatherStationModel>(response.Content);
       



        }
    }
}
