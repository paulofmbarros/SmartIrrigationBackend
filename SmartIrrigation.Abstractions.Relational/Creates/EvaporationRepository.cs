using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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
        public int InsertEvaporationData(string[] lines, int Id_District)
        {
            int affectedRows = 0;
            //using (IDbConnection db = new SqlConnection(_connectionString))
            string sql =
                "INSERT INTO Hist_Evaporation (Reading_date,Minimum,Maxi,Range,Mean,Std,Id_County) Values (@valores);";
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                
                    cn.Open();
                    for (int i = 0; i < lines.Length; i++)
                    {
                        if (i != 0&&!string.IsNullOrWhiteSpace(lines[i])) //ingore first line cause the first line is the headers of csv
                        {
                            string val = $"'{lines[i].Split(',').First()}',{string.Join(",", lines[i].Split(',').Skip(1).ToArray())}, {Id_District}";
                            string SqlQuery = sql;
                            SqlQuery=SqlQuery.Replace("@valores", val);

                        using (SqlCommand cmd = new SqlCommand(SqlQuery, cn))
                        {
                               affectedRows+=cmd.ExecuteNonQuery();
                        }
                            //affectedRows += db.Execute(sql);

                        }
                    }
                    cn.Close();
            }

            return affectedRows;
        }
    }
}
