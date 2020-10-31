using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using SmartIrrigationConfigurationService;

namespace PositionStackAPI.ReverseGeocoding
{ 
    public class ReverseGeocoding:IReverseGeocoding
    {
        private readonly IConfig _config;

        public ReverseGeocoding(IConfig config)
        {
            _config = config;
        }
        public void GetAddressFromCoords(string latitude, string longitude)
        {
            RestClient client = new RestClient($"{_config.GetConfiguration("PositionStackAPI:APIBASICURI")}forward");
            var request = new RestRequest();

            request.AddHeader("access_key ", _config.GetConfiguration("PositionStackAPI:APIKEY"));
            request.AddHeader("Accept", "*/*");
            request.AddHeader("Accept-Encoding", "gzip, deflate");
            request.AddHeader("User-Agent", "runscope/0.1");
            request.Method = Method.GET;
            request.AddParameter("query", $"{latitude} {longitude}");

            var response = client.Execute(request);
        }
    }
}
