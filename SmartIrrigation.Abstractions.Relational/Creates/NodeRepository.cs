using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dapper;
using SmartIrrigation.Abstractions.Relational.Configuration;
using SmartIrrigationModels.Models.Geocoding;

namespace SmartIrrigation.Abstractions.Relational.Creates
{
    public class NodeRepository:INodeRepository
    {
        private readonly IConfigRelational _config;
        private readonly string _connectionString;

        public NodeRepository(IConfigRelational config)
        {
            _config = config;
            _connectionString = _config.GetConnectionString("ConnectionStrings:mydb1");
        }
        public void AddNewNode(GeocodingAddressModelQueryParams address,  bool isRealSensor,  bool isSprinkler,  bool isEnable, int locationIdLocation, int IdNearStation)
        {

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string sqlSelect = "Select Count(*) From Node";
                int count =db.QueryFirst<int>(sqlSelect);
                string sqlInsert = $"IF NOT EXISTS (SELECT Id_Node, FROM Node WHERE Id_Location = @IdLocation) INSERT INTO Node (Description_Node_{count},Id_Location,Id_NearStation,Is_enable,Is_RealSensor,Is_Sprinkler) Values (@Description,@Id_Location,@Id_NearStationOrSensor,@Is_enable,@Is_RealSensor,@Is_Sprinkler)";
                db.Execute(sqlInsert, new { Description = address.Street, Id_Location = locationIdLocation, Altitude = 0, Id_NearStation = IdNearStation, Is_enable = isEnable, Is_RealSensor = isRealSensor, Is_Sprinkler=isSprinkler });
            }

            //return affectedRows;
        }
    }
}
