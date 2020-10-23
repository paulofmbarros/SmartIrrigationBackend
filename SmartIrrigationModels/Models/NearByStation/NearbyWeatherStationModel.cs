using SmartIrrigationModels.Models.WeatherStation;

namespace SmartIrrigationModels.Models.NearByStation
{
    public class NearbyWeatherStationModel : WeatherStationModel 
    {
        public double Distance { get; set; }
    }
}
