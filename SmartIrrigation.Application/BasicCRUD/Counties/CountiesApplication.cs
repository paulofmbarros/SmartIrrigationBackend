using SmartIrrigation.Domain.BasicCRUD.Counties;
using SmartIrrigationModels.Models.DTOS;

namespace SmartIrrigation.Application.BasicCRUD.Counties
{
   public class CountiesApplication : ICountiesApplication
   {
       private readonly ICountiesDomain _countiesDomain;

       public CountiesApplication(ICountiesDomain countiesDomain)
       {
           _countiesDomain = countiesDomain;
       }

       public County GetCountyByCountyName(string countyName) => _countiesDomain.GetCountyByCountyName(countyName);


   }
}
