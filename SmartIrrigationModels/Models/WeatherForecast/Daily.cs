using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIrrigationModels.Models.WeatherForecast
{
    public class Daily
    {
        public string? Dt { get; set; }
        public string? Sunrise { get; set; }
        public string? Sunset { get; set; }
        public Temperature? Temp { get; set; }
        public Feels_Like? Feels_like { get; set; }
        public float? Pressure { get; set; }
        public float? Humidity { get; set; }
        public float? Dew_point { get; set; }
        public float? Wind_Speed { get; set; }
        public float? Wind_Deg { get; set; }
        public List<Weather> Weather { get; set; }
        public int? Clouds { get; set; }
        public float? Pop { get; set; }
        public float? Rain { get; set; }
        public float? Uvi { get; set; }

    }
}
