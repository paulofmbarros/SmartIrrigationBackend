using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RestSharp;
using SmartIrrigationConfigurationService;
using SmartIrrigationModels.Models;
using SmartIrrigationModels.Models.Geocoding;
using SmartIrrigationModels.Models.WeatherStation;

namespace PositionStackAPI.ForwardGeocoding
{
    public class ForwardGeocodingService :IForwardGeocodingService
    {
        private readonly IConfig _config;

        public ForwardGeocodingService(IConfig config)
        {
            _config = config;
        }
        public RootGeocodingDataModel<GeocodingAddressResponseModel> GetCoordsFromAddress(GeocodingAddressModelQueryParams queryparams)
        {
            RestClient client = new RestClient($"{_config.GetConfiguration("PositionStackAPI:APIBASICURI")}forward");
            var request = new RestRequest();

            request.AddHeader("Accept", "*/*");
            request.AddHeader("Accept-Encoding", "gzip, deflate");
            request.AddHeader("User-Agent", "runscope/0.1");
            request.Method = Method.GET;
            request.AddParameter("access_key", _config.GetConfiguration("PositionStackAPI:APIKEY"));
            request.AddParameter("query", $"{queryparams.Street}, {queryparams.County},{queryparams.District}");

            var response = client.Execute(request);
            RootGeocodingDataModel<GeocodingAddressResponseModel> content = JsonConvert.DeserializeObject<RootGeocodingDataModel<GeocodingAddressResponseModel>>(response.Content);


            foreach (var data in content.Data)
            {

                data.Latitude.Replace(',', '.');
                data.Longitude.Replace(',', '.');
            }

            return content;

        }
    }
}
