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
    public sealed class ReadDistrictInformation :IReadDistrictInformation
    {
        private readonly IConfigRelational _config;
        private readonly string _connectionString;

        public ReadDistrictInformation(IConfigRelational config)
        {
            _config = config;
            _connectionString = _config.GetConnectionString("ConnectionStrings:mydb1");
        }
        public District RetrieveDistrictByDistrictName(string districtName)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string command = $"SELECT  [Id_District], [DistrictName] FROM [dbo].[District] where [DistrictName]= @DistrictName";
                return db.QueryFirstOrDefault<District>(command, new { DistrictName = districtName});
                
            }
            
        }

        public District RetrieveDistrictByCountyName(string countyName)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string command = @$"SELECT TOP (1000) D.[Id_District], [DistrictName]
                                   FROM [dbo].[District] D
                                   LEFT JOIN [dbo].[Counties] C
                                   ON C.Id_District = D.Id_District
                                   WHERE C.Name = @CountyName";
                return db.QueryFirstOrDefault<District>(command, new { CountyName= countyName });

            }

        }
    }
}
