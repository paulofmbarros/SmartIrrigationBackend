using SmartIrrigationModels.Models.DTOS;

namespace SmartIrrigation.Domain.BasicCRUD.Counties
{
    public interface ICountiesDomain
    {
        County GetCountyByCountyName(string countyName);
    }
}
