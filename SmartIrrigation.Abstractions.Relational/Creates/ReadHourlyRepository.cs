using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Dapper;
using SmartIrrigation.Abstractions.Relational.Configuration;
using SmartIrrigationModels.Models;
using SmartIrrigationModels.Models.DTOS;
using SmartIrrigationModels.Models.WeatherData;
using SmartIrrigationModels.Models.WeatherForecast;

namespace SmartIrrigation.Abstractions.Relational.Creates
{
    public class ReadHourlyRepository : IReadHourlyRepository
    {
        private readonly IConfigRelational _config;
        private readonly string _connectionString;

        public ReadHourlyRepository(IConfigRelational config)
        {
            _config = config;
            _connectionString = _config.GetConnectionString("ConnectionStrings:mydb1");
        }


        public int AddReadHourly(RootWeatherDataModel<HourlyDataModel> rootWeatherDataModel, bool isStation, int? idStation, int idNode)
        {
            int rowsupdated = 0;
            using (IDbConnection db = new SqlConnection(_connectionString))
            {

                foreach (var item in rootWeatherDataModel.Data)
                {
                    string sql =
                        $"IF NOT EXISTS (SELECT * FROM [dbo].[Read_Hourly] WHERE DateReading = @DateReading and IdNode = @IdNode) " +
                        $"Insert into [dbo].[Read_Hourly] (DateReading,Temperature,Dwpt, Rhum, Prcp, Snow, Wdir, Wspd, Wpgt, Pres, Tsun, Coco, IsStation, IdNode) values (@DateReading, @Temperature, @Dwpt, @Rhum, @Prcp, @Snow, @Wdir, @Wspd, @Wpgt, @Pres, @Tsun, @Coco, @IsStation, @IdNode)";
                    rowsupdated = db.Execute(sql,
                         new
                         {
                             DateReading = item.Time,
                             Temperature = item.Temp,
                             Dwpt = item.Dwpt,
                             Rhum = item.Rhum,
                             Prcp = item.Prcp,
                             Snow = item.Snow,
                             Wdir = item.WDir,
                             Wspd = item.WSpd,
                             Wpgt = item.WPgt,
                             Pres = item.Pres,
                             Tsun = item.Tsun,
                             Coco = item.Coco,
                             isStation = isStation,
                             idNode = idNode
                         });
                }
            }

            return rowsupdated;
        }

        public List<Read_Hourly> GetWeatherConditionsForAllActiveNodes()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {


                string sql = @"SELECT R.[Id_Read]
                            ,[DateReading]
                            ,R.[Temperature]
                            ,R.[Dwpt]
                            ,R.[Rhum]
                            ,R.[Prcp]
                            ,R.[Snow]
                            ,R.[Wdir]
                            ,R.[Wspd]
                            ,R.[Wpgt]
                            ,R.[Pres]
                            ,R.[Tsun]
                            ,R.[Coco]
                            ,R.[IsStation]
                            ,R.[IdNode]
                    FROM[smartirrigationdatabase].[dbo].[Node] N
                        inner join[smartirrigationdatabase].[dbo].[Read_Hourly] R on R.IdNode = N.Id_Node
                    where N.Is_Enable = 1 and(Select Format(DateReading, 'yyyy-MM-dd')) = (Select format(CAST(GETDATE() as date), 'yyyy-MM-dd') as date)";
                return db.Query<Read_Hourly>(sql).ToList();

            }
        }
    }
}
