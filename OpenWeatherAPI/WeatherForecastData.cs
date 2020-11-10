using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RestSharp;
using SmartIrrigationConfigurationService;
using SmartIrrigationModels.Models;
using SmartIrrigationModels.Models.WeatherForecast;

namespace OpenWeatherAPI
{
    public class WeatherForecastData :IWeatherForecastData
    {
        private readonly IConfig _config;

        public WeatherForecastData(IConfig config)
        {
            _config = config;
        }
        public RootWeatherForecast<Daily> GetWeatherForecast(string latitude, string longitude)
        {
            RestClient client = new RestClient($"{_config.GetConfiguration("Openweathermap:APIBASICURI")}onecall");
            var request = new RestRequest();

            request.AddHeader("Accept", "*/*");
            request.AddHeader("Accept-Encoding", "gzip, deflate");
            request.AddHeader("User-Agent", "runscope/0.1");
            request.Method = Method.GET;
            request.AddParameter("lat", latitude, ParameterType.QueryString);
            request.AddParameter("lon", longitude, ParameterType.QueryString);
            request.AddParameter("exclude", "current,minutely,hourly,alerts", ParameterType.QueryString);
            request.AddParameter("appid", _config.GetConfiguration("Openweathermap:APIKEY"), ParameterType.QueryString);
            request.AddParameter("units", "metric", ParameterType.QueryString);

            var response = client.Execute(request);
            try
            {
                var x = JsonConvert.DeserializeObject<RootWeatherForecast<Daily>>(response.Content);
                return x;
            }
            catch (Exception ex)
            {
                return  new RootWeatherForecast<Daily>();
                ;
            }
            

        }
    }
}
