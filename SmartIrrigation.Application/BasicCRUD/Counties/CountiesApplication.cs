using System;
using System.Collections.Generic;
using System.Text;
using SmartIrrigation.Application.BasicCRUD.Counties;
using SmartIrrigation.Domain.BasicCRUD.Counties;
using SmartIrrigationModels.Models.DTOS;

namespace SmartIrrigation.Application.BasicCRUD
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
