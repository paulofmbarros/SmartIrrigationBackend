using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using DevMeteoStat.Configuration;
using RestSharp;

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
            //request.AddQueryParameter("limit", limit.ToString());


            var response = client.Execute(request);
            var result = response.Content;
            
            return result;

        }
    }
}
