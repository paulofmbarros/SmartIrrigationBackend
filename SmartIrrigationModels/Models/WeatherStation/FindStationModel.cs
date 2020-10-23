namespace SmartIrrigationModels.Models.WeatherStation
{
    public class FindStationModel
    {
        public string Query { get; set; }
        public int? Limit { get; set; } = 8;
    }
}
