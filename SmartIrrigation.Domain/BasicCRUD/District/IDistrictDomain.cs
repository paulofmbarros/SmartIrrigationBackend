using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIrrigation.Domain.BasicCRUD.District
{
    public interface IDistrictDomain
    {
       SmartIrrigationModels.Models.DTOS.District GetDistrictByDistrictName(string districtName);
       SmartIrrigationModels.Models.DTOS.District RetrieveDistrictByCountyName(string countyName);
    }
}
