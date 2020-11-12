using System;
using System.Collections.Generic;
using System.Text;
using SmartIrrigationModels.Models.DTOS;

namespace SmartIrrigation.Application.BasicCRUD.Districts
{
    public interface IDistrictApplication
    {
        District GetDistrictByDistrictName(string districtName);
        District RetrieveDistrictByCountyName(string countyName);
    }
}
