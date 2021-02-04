using System.Linq;
using SmartIrrigation.Domain;
using SmartIrrigation.Domain.BasicCRUD.Location;
using SmartIrrigation.Domain.Node;
using SmartIrrigationModels.Models;
using SmartIrrigationModels.Models.DTOS;
using SmartIrrigationModels.Models.WeatherForecast;

namespace SmartIrrigation.Application.WeatherForecast
{
    public class WeatherForecastApplication : IWeatherForecastApplication
    {
        private readonly IWeatherForecastDomain _weatherForecastDomain;
        private readonly INodeDomain _nodeDomain;
        private readonly ILocationDomain _locationDomain;
        public WeatherForecastApplication(IWeatherForecastDomain weatherForecastDomain, INodeDomain nodeDomain, ILocationDomain locationDomain)
        {
            _weatherForecastDomain = weatherForecastDomain;
            _nodeDomain = nodeDomain;
            _locationDomain = locationDomain;
        }

        public RootWeatherForecast<Daily> GetWeatherForecast(string latitude, string longitude) => _weatherForecastDomain.GetWeatherForecast(latitude, longitude);

        public object GetWeatherForecastByIdNode(int idNode)
        {
            SmartIrrigationModels.Models.DTOS.Node node = _nodeDomain.GetAllActiveNodes()
                .Where(x => x.Id_Node == idNode).FirstOrDefault();
            Location nodeLocation = _locationDomain.RetrieveLocationByNodeId(node.Id_Node);
            return _weatherForecastDomain.GetWeatherForecast(nodeLocation.Latitude, nodeLocation.Longitude);


        }
    }
}
