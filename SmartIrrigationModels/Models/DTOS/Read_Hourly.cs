using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SmartIrrigationModels.Models.DTOS
{
    public class Read_Hourly
    {
        public int Id_Read { get; set; }
        public DateTime DateReading { get; set; }
        public float Temperature { get; set; }
        public float Dwpt { get; set; }
        public int Rhum { get; set; }
        public float Prcp { get; set; }
        public int Snow { get; set; }
        public int Wdir { get; set; }
        public float Wspd { get; set; }
        public float Wpgt { get; set; }
        public float Pres { get; set; }
        public int Tsun { get; set; }
        public int Coco { get; set; } 
        public bool IsStation { get; set; } 
        public int IdNode { get; set; } 

        public Read_Hourly(int idRead, DateTime dateReading, float temperature, float dwpt, int rhum, float prcp, int snow, int wdir, float wspd, float wpgt, float pres, int tsun, int coco, bool isStation, int idNode)
        {
            Id_Read = idRead;
            DateReading = dateReading;
            Temperature = temperature;
            Dwpt = dwpt;
            Rhum = rhum;
            Prcp = prcp;
            Snow = snow;
            Wdir = wdir;
            Wspd = wspd;
            Wpgt = wpgt;
            Pres = pres;
            Tsun = tsun;
            Coco = coco;
            IsStation = isStation;
            IdNode = idNode;
        }

        public Read_Hourly()
        {

        }
    }
}
