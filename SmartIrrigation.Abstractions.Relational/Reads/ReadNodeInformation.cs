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

        public Node RetrieveNodeByLatLong(string latitude, string longitude)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string command = $@" SELECT N.* FROM [dbo].[Node] N
                    inner join [dbo].[Location] L on N.Id_Location = L.Id_Location
                where L.Latitude = @latitude and L.Longitude = @longitude";

                return db.QueryFirstOrDefault<Node>(command, new { latitude = latitude, longitude=longitude });

            }
        }

        public IEnumerable<Node> GetAllActiveNodes()
        {

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string command = $@" SELECT * FROM [dbo].[Node] where is_Enable = 1";

                return db.Query<Node>(command);

            }
        }
    }
}
