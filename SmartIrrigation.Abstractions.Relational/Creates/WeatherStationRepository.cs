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
    public class WeatherStationRepository:IWeatherStationRepository
    {
        private readonly IConfigRelational _config;
        private readonly string _connectionString;

        public WeatherStationRepository(IConfigRelational config)
        {
            _config = config;
            _connectionString = _config.GetConnectionString("ConnectionStrings:mydb1");
        }
        public void AddWeatherStationToDatabase(Station station)
        {
            int affectedRows = 0;

            using (IDbConnection db = new SqlConnection(_connectionString))
            {

                string sql = @"IF NOT EXISTS ( SELECT [Id_Station]
                              ,[Name]
                              ,[Country]
                              ,[Regional]
                              ,[National]
                              ,[Wmo]
                              ,[Icao]
                              ,[Iata]
                              ,[Elevation]
                              ,[Timezone]
                              ,[Active]
                              ,[Id_Location]
                          FROM [smartirrigationdatabase].[dbo].[Station] WHERE [Id_Location] = @Id_Location) 
                         INSERT INTO Station (
                              [Name]
                              ,[Country]
                              ,[Regional]
                              ,[National]
                              ,[Wmo]
                              ,[Icao]
                              ,[Iata]
                              ,[Elevation]
                              ,[Timezone]
                              ,[Active]
                              ,[Id_Location]) Values (@Name,@Country,@Regional,@Nat,@Wmo,@Icao, @Iata, @Elevation, @Timezone, @Active, @Id_Location)";
                affectedRows += db.Execute(sql, new { Name = station.Name, Country = station.Country, Regional = station.Regional, Nat = station.National, Wmo = station.Wmo, Icao=station.Icao ,Iata=station.Iata, Elevation=station.Elevation, Timezone=station.Timezone, Active=station.Active, Id_Location=station.Id_Location});



            }

            //return affectedRows;
        }
    }
}
