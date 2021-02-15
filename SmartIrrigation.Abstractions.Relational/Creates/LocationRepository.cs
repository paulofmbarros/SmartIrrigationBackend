using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dapper;
using SmartIrrigation.Abstractions.Relational.Configuration;
using SmartIrrigationModels.Models;
using SmartIrrigationModels.Models.DTOS;
using SmartIrrigationModels.Models.Geocoding;

namespace SmartIrrigation.Abstractions.Relational.Creates
{
    public class LocationRepository :ILocationRepository
    {
        private readonly IConfigRelational _config;
        private readonly string _connectionString;

        public LocationRepository(IConfigRelational config)
        {
            _config = config;
            _connectionString = _config.GetConnectionString("ConnectionStrings:mydb1");
        }


        public int InsertLocationData(RootGeocodingDataModel<GeocodingAddressResponseModel> data, int Id_District, int Id_County)
        {
            int affectedRows = 0;
            
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                foreach (GeocodingAddressResponseModel location in data.Data)
                {
                    string sql = "IF NOT EXISTS (SELECT Latitude,Longitude FROM Location WHERE Latitude = @Latitude AND Longitude=@Longitude) INSERT INTO Location (Latitude,Longitude,Altitude,Description,id_District,Id_Countie) Values (@Latitude,@Longitude,@Altitude,@Description,@Id_District,@Id_County)";
                    affectedRows += db.Execute(sql, new { Latitude = location.Latitude, Longitude = location.Longitude, Altitude=0, Description=location.Name, Id_District= Id_District, Id_County=Id_County });

                }

            }

            return affectedRows;
        }

        public int InsertLocationData(Location data, int Id_District, int Id_County)
        {
            int affectedRows = 0;

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
               
                    string sql = "IF NOT EXISTS (SELECT Latitude,Longitude FROM Location WHERE Latitude = @Latitude AND Longitude=@Longitude) INSERT INTO Location (Latitude,Longitude,Altitude,Description,Id_District,Id_Countie) Values (@Latitude,@Longitude,@Altitude,@Description,@Id_District,@Id_County)";
                    affectedRows += db.Execute(sql, new { Latitude = data.Latitude, Longitude = data.Longitude, Altitude = 0, Description = data.Description, Id_District = Id_District, Id_County = Id_County });

               

            }

            return affectedRows;
        }

        public Location RetrieveLocationData(string latitude, string longitude)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                
                    string sql = "Select * from Location where Latitude=@Latitude and Longitude=@Longitude";
                    return db.QueryFirstOrDefault<Location>(sql, new { Latitude = latitude, Longitude = longitude});

                

            }
        }

        public Location RetrieveLocationByNodeId(int nodeId)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {

                string sql = "SELECT  L.* FROM [dbo].[Node] N " +
                             "inner join  [dbo].[Location] L on N.Id_Location = L.Id_Location " +
                             "where N.Id_Node = @NodeId";
                return db.QueryFirstOrDefault<Location>(sql, new { NodeId = nodeId });



            }
        }
    }
}
