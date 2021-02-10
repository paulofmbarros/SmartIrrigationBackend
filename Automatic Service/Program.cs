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
using System.Globalization;
using System.Linq.Expressions;


namespace Automatic_Service
{
    class Program
    {

        static void Main(string[] args)
        {
            ConsumeEventSync objsync = new ConsumeEventSync();

            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            //de 24 em 24 horas executa esta task começando as 10:20
            TaskScheduler.Instance.ScheduleTask(10, 20, 24, () =>
              {
                  objsync.UpdateWeatherConditionsForAllActiveNodes();
                  objsync.UpdateHistoryEvaporationForAllActiveCounties();
              });

            // DE 30 EM 30 min TEMPO VER OS PARAMETROS QUE ESTAO NA BASE DE DADOS E COMPRAR COM AS METRICAS E COM ISSO LIGAR OU NAO O SISTEMA DE REGA
            TaskScheduler.Instance.ScheduleTask(10, 20, 0.5, () =>
            {


                MetricsComparisonLogicService metricsService = new MetricsComparisonLogicService();
                List<List<Read_Hourly>> activeNodesWith24HoursReadings =
                    objsync.GetWeatherConditionsForAllActiveNodes();

                foreach (var node in activeNodesWith24HoursReadings)
                {
                   #region AlertRegion


                   List<double> temperaturesOfANode = node.Select(x => (double)x.Temperature).ToList();
                    List<double> pressureOfANode = node.Select(x => (double)x.Pres).ToList();
                    List<double> precipitationOfANode = node.Select(x => (double)x.Prcp).ToList();
                    List<double> humidityOfANode = node.Select(x => (double)x.Rhum).ToList();
                    List<string> Errors = new List<string>();



                    string MailBody = string.Empty;

                    if (MathService.getOutliers(temperaturesOfANode).Count > 0)
                    {
                        MathService.getOutliers(temperaturesOfANode).ForEach(x => temperaturesOfANode.Remove(x));
                        MailBody +=
                            $"There is a error found on Temperature sensor in {node.Select(z => z.IdNode).FirstOrDefault()} \n";
                        Errors.Add(MailBody);

                    }

                    if (MathService.getOutliers(pressureOfANode).Count > 0)
                    {
                        MathService.getOutliers(pressureOfANode).ForEach(x => pressureOfANode.Remove(x));
                        MailBody +=
                            $"There is a error found on Pressure sensor in {node.Select(z => z.IdNode).FirstOrDefault()} \n";
                        Errors.Add(MailBody);
                    }

                    if (MathService.getOutliers(precipitationOfANode).Count > 0)
                    {
                        MathService.getOutliers(precipitationOfANode).ForEach(x => precipitationOfANode.Remove(x));
                        MailBody +=
                            $"There is a error found on Precipitation sensor in {node.Select(z => z.IdNode).FirstOrDefault()}\n";
                        Errors.Add(MailBody);
                    }

                    if (MathService.getOutliers(humidityOfANode).Count > 0)
                    {
                        MathService.getOutliers(humidityOfANode).ForEach(x => humidityOfANode.Remove(x));
                        MailBody +=
                            $"There is a error found on Humidity sensor in {node.Select(z => z.IdNode).FirstOrDefault()}\n";
                        Errors.Add(MailBody);
                    }

                    if (Errors.Count > 0)
                        EmailSevice.SendEmail(MailBody, node.Select(z => z.IdNode).FirstOrDefault());

                   #endregion

                   RootWeatherForecast<Daily> forecast = objsync.GetWeatherForecast();
                    float EvapoTranspirationForLast30Days =
                        objsync.GetEvapoTranspirationForLast30Days(node.Select(z => z.IdNode).FirstOrDefault());

                    int timeSprinklerActivated = 0;

                    if (EvapoTranspirationForLast30Days <= float.Parse(config["Evapotranspiracao:Humida"],
                        CultureInfo.InvariantCulture.NumberFormat))
                        timeSprinklerActivated = int.Parse(config["TempoDeRegaEmMin:Humida"],
                            CultureInfo.InvariantCulture.NumberFormat);

                    if (EvapoTranspirationForLast30Days > float.Parse(config["Evapotranspiracao:Humida"],
                            CultureInfo.InvariantCulture.NumberFormat) && EvapoTranspirationForLast30Days <=
                        float.Parse(config["Evapotranspiracao:SubHumida"]))
                        timeSprinklerActivated = int.Parse(config["TempoDeRegaEmMin:SubHumida"],
                            CultureInfo.InvariantCulture.NumberFormat);


                    if (EvapoTranspirationForLast30Days > float.Parse(config["Evapotranspiracao:SubHumida"],
                            CultureInfo.InvariantCulture.NumberFormat) && EvapoTranspirationForLast30Days <=
                        float.Parse(config["Evapotranspiracao:SubHumidaSeca"]))
                        timeSprinklerActivated = int.Parse(config["TempoDeRegaEmMin:SubHumidaSeca"],
                            CultureInfo.InvariantCulture.NumberFormat);

                    if (EvapoTranspirationForLast30Days > float.Parse(config["Evapotranspiracao:SubHumidaSeca"],
                        CultureInfo.InvariantCulture.NumberFormat))
                        timeSprinklerActivated = int.Parse(config["TempoDeRegaEmMin:Semiarida"],
                            CultureInfo.InvariantCulture.NumberFormat);

                   //Checks The temperature  
                   if (metricsService.IsTheTemperatureOkToSprinkle(activeNodesWith24HoursReadings))
                    {
                        DateTime sunset =
                            DatetimeService.UnixTimeStampToDateTime(
                                double.Parse(forecast.Daily.FirstOrDefault().Sunset));
                        DateTime sunrise =
                            DatetimeService.UnixTimeStampToDateTime(
                                double.Parse(forecast.Daily.FirstOrDefault().Sunrise));
                       //checks if the time that is running is after sunset and before sunrise
                       if (DateTime.Now < sunrise && DateTime.Now > sunset)
                        {
                            if (!forecast.Daily.FirstOrDefault().Weather.FirstOrDefault().Main.ToLower()
                                    .Contains("rain") ||
                                !forecast.Daily.FirstOrDefault().Weather.FirstOrDefault().Main.ToLower()
                                    .Contains("rain"))
                            {
                               //activate sprinkler
                               objsync.ActivateSprinkler(node.Select(z => z.IdNode).FirstOrDefault());
                                Thread.Sleep(timeSprinklerActivated * 60 * 1000);
                                objsync.DeactivateSprinkler(node.Select(z => z.IdNode).FirstOrDefault());

                            }
                        }
                    }
                }
            });

        }


    }
}
