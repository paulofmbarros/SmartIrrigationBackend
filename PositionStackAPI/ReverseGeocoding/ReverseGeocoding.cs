using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RestSharp;
using SmartIrrigationConfigurationService;
using SmartIrrigationModels.Models;
using SmartIrrigationModels.Models.Geocoding;

namespace PositionStackAPI.ReverseGeocoding
{ 
    public class ReverseGeocoding:IReverseGeocoding
    {
        private readonly IConfig _config;

        public ReverseGeocoding(IConfig config)
        {
            _config = config;
        }
        public RootGeocodingDataModel<GeocodingAddressResponseModel> GetAddressFromCoords(string latitude, string longitude)
        {
            RestClient client = new RestClient($"{_config.GetConfiguration("PositionStackAPI:APIBASICURI")}reverse");
            var request = new RestRequest();

            request.AddHeader("Accept", "*/*");
            request.AddHeader("Accept-Encoding", "gzip, deflate");
            request.AddHeader("User-Agent", "runscope/0.1");
            request.Method = Method.GET;
            request.AddParameter("access_key", _config.GetConfiguration("PositionStackAPI:APIKEY"));
            request.AddParameter("query", $"{latitude}, {longitude}");

            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<RootGeocodingDataModel<GeocodingAddressResponseModel>>(response.Content);

        }
    }
}
