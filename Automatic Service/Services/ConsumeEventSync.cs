using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SmartIrrigationModels.Models;
using SmartIrrigationModels.Models.DTOS;
using SmartIrrigationModels.Models.WeatherForecast;

namespace Automatic_Service.Services
{
    public class ConsumeEventSync
    {
        public List<List<Read_Hourly>> GetWeatherConditionsForAllActiveNodes() //Get All Events Records  
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44351/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                var response =  client.GetAsync("api/WeatherHistory/GetWeatherConditionsForAllActiveNodes").Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseAsString = response.Content.ReadAsStringAsync().Result;
                    return  JsonConvert.DeserializeObject<List<Read_Hourly>>(responseAsString).GroupBy(u=>u.IdNode).Select(grp=>grp.ToList()).ToList(); //first list is represent each of all active nodes and inside of thi slist we ahve a list of read_hourly objects of last 24 hours

                }
                return new List<List<Read_Hourly>>();
            }
        }

        public RootWeatherForecast<Daily> GetWeatherForecast() //Get All Events Records  
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44351/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                var response = client.GetAsync("api/WeatherForecast/GetWeatherForecastByIdNode?idNode=1").Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseAsString = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<RootWeatherForecast<Daily>>(responseAsString);

                }
                return new RootWeatherForecast<Daily>();
            }
        }
    }
    
}
