﻿using System;
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
        public void GetCoordsFromAddress(GeocodingAddressModelQueryParams queryparams)
        {
            RestClient client = new RestClient($"{_config.GetConfiguration("PositionStackAPI:APIBASICURI")}forward");
            var request = new RestRequest();

            request.AddHeader("access_key ", _config.GetConfiguration("PositionStackAPI:APIKEY"));
            request.AddHeader("Accept", "*/*");
            request.AddHeader("Accept-Encoding", "gzip, deflate");
            request.AddHeader("User-Agent", "runscope/0.1");
            request.Method = Method.GET;
            request.AddParameter("query", $"{queryparams.Street} {queryparams.County},{queryparams.District}");

            var response = client.Execute(request);
            //return JsonConvert.DeserializeObject<RootWeatherStationModel<WeatherStationWithParamsModel>>(response.Content);

        }
    }
}
