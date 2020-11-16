﻿using System;
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
                    string sql = "IF NOT EXISTS (SELECT Latitude,Longitude FROM Location WHERE Latitude = @Latitude AND Longitude=@Longitude) INSERT INTO Location (Latitude,Longitude,Altitude,Description,District,Countie) Values (@Latitude,@Longitude,@Altitude,@Description,@Id_District,@Id_County)";
                    affectedRows += db.Execute(sql, new { Latitude = location.Latitude, Longitude = location.Longitude, Altitude=0, Description=location.Name, Id_District= Id_District, Id_County=Id_County });

                }

            }

            return affectedRows;
        }
    }
}