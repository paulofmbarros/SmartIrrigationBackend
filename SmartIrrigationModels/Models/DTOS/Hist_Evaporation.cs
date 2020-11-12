using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIrrigationModels.Models.DTOS
{
    public class Hist_Evaporation
    {
        public int Id_HistEvaporation { get; set; }
        public DateTime Reading_Date { get; set; }
        public float Minimum { get; set; }
        public float Maxi { get; set; }
        public float Range { get; set; }
        public float Mean { get; set; }
        public float Std { get; set; }
        public int Id_County { get; set; }
    }
}
