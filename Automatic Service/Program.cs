using System;
using System.Timers;
using Automatic_Service.Services;

namespace Automatic_Service
{
    class Program
    {
        static void Main(string[] args)
        {
           
            // de 24 em 24 horas executa esta task começando as 10:20
            TaskScheduler.Instance.ScheduleTask(10,20,24, () =>
            {
                //pedido http para preencher todas as bases de dados
            });

            //DE 30 EM 30 min TEMPO VER OS PARAMETROS QUE ESTAO NA BASE DE DADOS E COMPRAR COM AS METRICAS E COM ISSO LIGAR OU NAO O SISTEMA DE REGA
            TaskScheduler.Instance.ScheduleTask(10, 20, 0.5, () =>
            {
                //pedido http para ativar o sistema de rega mediante os valores1
            });
        }


    }
}
