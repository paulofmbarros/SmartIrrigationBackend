using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Timers;
using Automatic_Service.Services;
using SmartIrrigationModels.Models.DTOS;

namespace Automatic_Service
{
    class Program
    {

        static HttpClient client = new HttpClient();

        static void Main(string[] args)
        {
            Thread.Sleep(5000);
           
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

                //Checks The temperature  
                if (metricsService.IsTheTemperatureOkToSprinkle(activeNodesWith24HoursReadings))
                {

                }


                //dados atuais


                //previsão + ver a que horas se poe o sol hoje


                // olhar para as metricas

                //ligar ou nao ligar

                //});
        }


    }
}
