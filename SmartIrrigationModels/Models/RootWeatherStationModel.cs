using System.Collections.Generic;
using SmartIrrigationModels.Models.NearByStation;

namespace SmartIrrigationModels.Models.WeatherStation
{
    public class RootWeatherStationModel<T> where T : WeatherStationModel
    {
        public List<T> Data { get; set; }

    }

}
