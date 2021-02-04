using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Timers;
using Automatic_Service.Services;
using Microsoft.Extensions.Configuration;
using SmartIrrigationModels.Models;
using SmartIrrigationModels.Models.DTOS;
using SmartIrrigationModels.Models.WeatherForecast;
using Microsoft.Extensions.Configuration.Json;
using System.Configuration;



namespace Automatic_Service
{
    class Program
    {

        static HttpClient client = new HttpClient();

        static void Main(string[] args)
        {

            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            var name = config["name"];
            Console.WriteLine($"Hello {name}!");

            // de 24 em 24 horas executa esta task começando as 10:20
            //TaskScheduler.Instance.ScheduleTask(10,20,24, () =>
            //{
            //    //pedido http para preencher todas as bases de dados \/
            //});

            //DE 30 EM 30 min TEMPO VER OS PARAMETROS QUE ESTAO NA BASE DE DADOS E COMPRAR COM AS METRICAS E COM ISSO LIGAR OU NAO O SISTEMA DE REGA
            //TaskScheduler.Instance.ScheduleTask(10, 20, 0.5, () =>
            //{
            //pedido http para ativar o sistema de rega mediante os valores1
            ConsumeEventSync objsync = new ConsumeEventSync();
                MetricsComparisonLogicService metricsService = new MetricsComparisonLogicService();
                List<List<Read_Hourly>> activeNodesWith24HoursReadings = objsync.GetWeatherConditionsForAllActiveNodes();


            RootWeatherForecast<Daily> forecast = objsync.GetWeatherForecast();



            //Checks The temperature  
            if (metricsService.IsTheTemperatureOkToSprinkle(activeNodesWith24HoursReadings))
            {
                DateTime sunset = DatetimeService.UnixTimeStampToDateTime(double.Parse(forecast.Daily.FirstOrDefault().Sunset));
                DateTime sunrise = DatetimeService.UnixTimeStampToDateTime(double.Parse(forecast.Daily.FirstOrDefault().Sunrise));
                //checks if the time that is running is after sunset and before sunrise
                if (DateTime.Now < sunrise && DateTime.Now > sunrise)
                {
                    if (!forecast.Daily.FirstOrDefault().Weather.FirstOrDefault().Main.ToLower().Contains("rain") ||
                        !forecast.Daily.FirstOrDefault().Weather.FirstOrDefault().Main.ToLower().Contains("rain"))
                    {

                    }
                }
            }


                //dados atuais


                //previsão + ver a que horas se poe o sol hoje


                // olhar para as metricas

                //ligar ou nao ligar

                //});
        }


    }
}
