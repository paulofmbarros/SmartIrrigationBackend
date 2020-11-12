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

        public ReadCountiesInformation(IConfigRelational config)
        {
            _config = config;
            _connectionString = _config.GetConnectionString("ConnectionStrings:mydb1");
        }
        public County RetrieveCountyByCountyName(string countyName)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string readSp = $"SELECT [CountyId],[Name], [Id_District] FROM [dbo].[Counties] where [Name]= '{countyName}'";
                var x = db.QueryFirstOrDefault<County>(readSp);
                return x;
            }

        }
        
    }
}
