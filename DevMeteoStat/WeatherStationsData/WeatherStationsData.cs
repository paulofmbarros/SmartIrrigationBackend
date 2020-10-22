using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using DevMeteoStat.Configuration;
using RestSharp;
using SmartIrrigationModels.Models;

namespace DevMeteoStat.WeatherStationsData
{
    public class WeatherStationsData : IWeatherStationsData
    {
        public string FindWeatherStation(string query, int? limit)
        {
            
            RestClient client = new RestClient($"{Config.GetConfiguration("APIBASICURI")}stations/search");
            var request = new RestRequest();

            request.AddHeader("x-api-key", Config.GetConfiguration("APIKEY"));
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

            request.AddHeader("x-api-key", Config.GetConfiguration("APIKEY"));
            request.Method = Method.GET;
            request.AddParameter("lat",findNearbyStationModel.Latitude);
            request.AddParameter("long", findNearbyStationModel.Longitude);
            request.AddParameter("limit", findNearbyStationModel.Limit);

            var response = client.Execute(request);
            var result = response.Content;

            
        }
    }
}
