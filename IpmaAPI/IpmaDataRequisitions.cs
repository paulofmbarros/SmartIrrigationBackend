using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using RestSharp;
using SmartIrrigationModels.Models.DTOS;

namespace IpmaAPI
{
    public class IpmaDataRequisitions:IIpmaDataRequisitions
    {
        public string[] GetHistoryEvaporationByCountyName(County county, string districtName)
        {
            RestClient client = new RestClient($"https://api.ipma.pt/open-data/observation/climate/evapotranspiration/{districtName.ToLower()}/et0-{county.CountyId}-{county.Name.ToLower()}.csv");
            var request = new RestRequest();

            request.AddHeader("Accept", "*/*");
            request.AddHeader("Accept-Encoding", "gzip, deflate");
            request.AddHeader("User-Agent", "runscope/0.1");
            request.Method = Method.GET;
            var response = client.Execute(request).Content.Split("\n");
           
            
            return response;

        }
    }
}
