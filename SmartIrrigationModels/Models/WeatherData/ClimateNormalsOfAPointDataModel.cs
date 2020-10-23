using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIrrigationModels.Models.WeatherData
{
    public class ClimateNormalsOfAPointDataModel : ClimateNormalsDataModel
    {
        public float? Pres { get; set; }
        public int? Tsun { get; set; }
    }
}
