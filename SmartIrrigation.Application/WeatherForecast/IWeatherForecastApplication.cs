using SmartIrrigationModels.Models;
using SmartIrrigationModels.Models.WeatherForecast;

namespace SmartIrrigation.Application.WeatherForecast
{
    public interface IWeatherForecastApplication
    {
        RootWeatherForecast<Daily> GetWeatherForecast(string latitude, string longitude);
        object GetWeatherForecastByIdNode(int idNode);
    }
}
