using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dapper;
using SmartIrrigation.Abstractions.Relational.Configuration;
using SmartIrrigationModels.Models;
using SmartIrrigationModels.Models.Geocoding;

namespace SmartIrrigation.Abstractions.Relational.Creates
{
    public class SensorRepository :ISensorRepository
    {

        private readonly IConfigRelational _config;
        private readonly string _connectionString;

        public SensorRepository(IConfigRelational config)
        {
            _config = config;
            _connectionString = _config.GetConnectionString("ConnectionStrings:mydb1");
        }
        public int AddNewSensor(string description, int? idLocation, in int idNode, in bool isEnable)
        {
            int affectedRows = 0;

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string sqlSelect = "Select Count(*) From Sensor";
                int count =db.QueryFirst<int>(sqlSelect);
                string sqlInsert = $"INSERT INTO Sensor (Description,Id_Location,Id_Node,Is_enable) Values (@Description,@IdLocation,@Id_Node,@Is_enable)";
                affectedRows=db.Execute(sqlInsert, new { Description = $"{description}_Sensor{count}", IdLocation = idLocation, Id_Node=idNode, Is_enable = isEnable });
            }

            return affectedRows;
        }


        public int AddNewSensor(string description, string type, int IdLocation) 
        {
            int affectedRows = 0;

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string sqlSelect = "  Select top 1 IdNode from Node order by IdNode desc";
                int idNode = db.QueryFirst<int>(sqlSelect);
                string sqlInsert = $"INSERT INTO Sensor (Description,Id_Location,IdNode,IsEnable) Values (@Description,@IdLocation,@Id_Node,@Is_enable)";
                affectedRows = db.Execute(sqlInsert, new { Description = $"{description}_Sensor_{type}", IdLocation = IdLocation, Id_Node = idNode, Is_enable = 1 });
            }

            return affectedRows;
        }
    }
}
