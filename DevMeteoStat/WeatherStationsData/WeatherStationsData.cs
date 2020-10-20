using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using RestSharp;

namespace DevMeteoStat.WeatherStationsData
{
    public class WeatherStationsData : IWeatherStationsData
    {
        //private static readonly RestClient client = new RestClient($"https://api.meteostat.net/v2/stations/search");

        public string FindWeatherStation(string query)
        {
            RestClient client = new RestClient(new Uri($"https://api.meteostat.net/v2/stations/search"));
            var request = new RestRequest(Method.GET);

            request.AddHeader("x-api-key", "ZTebetkG3LJxLK0GUOzwstLmRRbEZmmT");
            request.AddParameter("query", query, ParameterType.RequestBody);

            //request.AddParameter("application/x-www-form-urlencoded", "grant_type=password&username=username&password=password", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var result = response.Content;

            return result;

        }
    }
}
