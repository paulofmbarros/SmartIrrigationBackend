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
    public class ReadNodeInformation :IReadNodeInformation
    {

        private readonly IConfigRelational _config;
        private readonly string _connectionString;

        public ReadNodeInformation(IConfigRelational config)
        {
            _config = config;
            _connectionString = _config.GetConnectionString("ConnectionStrings:mydb1");
        }

        public Node RetrieveNodeByStreet(string street)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string command = $"SELECT * FROM [dbo].[Node] where [Description] = @street";
                return db.QueryFirstOrDefault<Node>(command, new { street = street });

            }
        }
    }
}
