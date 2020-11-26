using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dapper;
using SmartIrrigation.Abstractions.Relational.Configuration;
using SmartIrrigationModels.Models.DTOS;

namespace SmartIrrigation.Abstractions.Relational.Reads
{
    public class ReadStationInformation :IReadStationInformation
    {
        private readonly IConfigRelational _config;
        private readonly string _connectionString;

        public ReadStationInformation(IConfigRelational config)
        {
            _config = config;
            _connectionString = _config.GetConnectionString("ConnectionStrings:mydb1");
        }

        public Station RetrieveStationByStationName(string stationName)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string command = $"SELECT * FROM [dbo].[Station] where [Name]= @Name";
                return db.QueryFirstOrDefault<Station>(command, new { Name = stationName });

            }
      }
    }
}
