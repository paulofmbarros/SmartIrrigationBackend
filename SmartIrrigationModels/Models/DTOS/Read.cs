using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIrrigationModels.Models.DTOS
{
    public class Read
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
    }
}
