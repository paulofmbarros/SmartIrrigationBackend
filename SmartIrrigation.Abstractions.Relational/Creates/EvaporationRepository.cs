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
        public int InsertEvaporationData(string[] lines, int Id_County)
        {
            int affectedRows = 0;
            //using (IDbConnection db = new SqlConnection(_connectionString))
            string sql =
                "IF NOT EXISTS (SELECT * FROM Hist_Evaporation WHERE Reading_date = @ReadingDate and Id_County= @Id_County)  " +
                " INSERT INTO Hist_Evaporation (Reading_date,Minimum,Maxi,Range,Mean,Std,Id_County) Values (@valores);";
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                
                    cn.Open();
                    for (int i = 0; i < lines.Length; i++)
                    {
                        if (i != 0&&!string.IsNullOrWhiteSpace(lines[i])) //ingore first line cause the first line is the headers of csv
                        {
                            string val = $"'{lines[i].Split(',').First()}',{string.Join(",", lines[i].Split(',').Skip(1).ToArray())}, {Id_County}";
                            string SqlQuery = sql;
                            SqlQuery=SqlQuery.Replace("@valores", val).Replace("@ReadingDate", $"'{lines[i].Split(',').First()}'").Replace("@Id_County", Id_County.ToString());

                        using (SqlCommand cmd = new SqlCommand(SqlQuery, cn))
                        {
                               affectedRows+=cmd.ExecuteNonQuery();
                        }

                        }
                    }
                    cn.Close();
            }

            return affectedRows;
        }

        public List<County> RetrieveCountiesThatHaveActiveNodes()
        {
            IEnumerable<County> counties;

            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                counties= cn.Query<County>($@"Select C.*from Location L
                                                join Counties C on L.Id_Countie = C.CountyId
                                                join Node N on N.Id_Location = L.Id_Location and N.Is_Enable = 1 and N.Is_Enable is not null");
            }

            return counties.ToList();
        }
    }
}
