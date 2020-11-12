using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using SmartIrrigation.Abstractions.Relational.Configuration;
using SmartIrrigationModels.Models.DTOS;
using System.Data.SqlClient;


namespace SmartIrrigation.Abstractions.Relational.Reads
{
    public class ReadCountiesInformation:IReadCountiesInformation
    {
        private readonly IConfigRelational _config;
        private readonly string _connectionString;

        public ReadCountiesInformation(IConfigRelational config, string connectionString)
        {
            _config = config;
            _connectionString = _config.GetConnectionString();
        }
        public County RetrieveCountyByCountyName(string countyName)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string readSp = "SELECT TOP (1) [CountyId],[Name], [Id_District] FROM [dbo].[Counties]";
                return db.QueryFirstOrDefault<County>(readSp);
            }
        }
    }
}
