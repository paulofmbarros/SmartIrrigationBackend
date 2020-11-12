using System;
using System.Collections.Generic;
using System.Text;
using SmartIrrigationModels.Models.DTOS;

namespace SmartIrrigation.Abstractions.Relational.Reads
{
    public interface IReadDistrictInformation
    {
        District RetrieveDistrictByDistrictName(string districtName);
        District RetrieveDistrictByCountyName(string countyName);
    }
}
