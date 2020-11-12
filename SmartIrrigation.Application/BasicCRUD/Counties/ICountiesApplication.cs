using SmartIrrigationModels.Models.DTOS;

namespace SmartIrrigation.Application.BasicCRUD.Counties
{
    public interface ICountiesApplication
    {
        County GetCountyByCountyName(string countyName);
    }
}
