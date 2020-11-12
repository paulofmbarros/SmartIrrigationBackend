using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dapper;
using SmartIrrigation.Abstractions.Relational.Configuration;
using SmartIrrigationModels.Models.DTOS;

namespace SmartIrrigation.Abstractions.Relational.Creates
{
   public class EvaporationRepository:IEvaporationRepository
    {
        private readonly IConfigRelational _config;
        private readonly string _connectionString;

        public EvaporationRepository(IConfigRelational config)
        {
            _config = config;
            _connectionString = _config.GetConnectionString("ConnectionStrings:mydb1");
        }
        public void InsertEvaporationData(string[] lines)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string sql =
                    "INSERT INTO Hist_Evaporation (Reading_date,Minimum,Maxi,Range,Mean,Std,Id_County) Values (@valores);";

                for (int i = 0; i < lines.Length; i++)
                {
                    //string x = $"'{lines[i].Replace(",", "','").ToString()}'";
                    if (i != 0)
                    {
                        var affectedRows = db.Execute(sql, new {valores = $"'{lines[i].Replace(",", "','")}'"});
                    }
                }
            }
        }
    }
}
