using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace SmartIrrigationModels.Models.WeatherData
{
    public class HourlyDataModel : WeatherModel
    {
        public string? Time { get; set; }
        public string? Time_Local { get; set; }
        public float?  Temp { get; set; }
        public float? Dwpt { get; set; }
        public float? Rhum { get; set; }
        public int? Snow { get; set; }
        public int? WDir { get; set; }
        public float? WSpd { get; set; }
        public float? WPgt { get; set; }
        public int? Coco { get; set; }



    }
}
