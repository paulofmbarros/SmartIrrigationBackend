using System;
using System.Collections.Generic;
using System.Text;
using SmartIrrigation.Domain.BasicCRUD.District;
using SmartIrrigationModels.Models.DTOS;

namespace SmartIrrigation.Application.BasicCRUD.Districts
{
    public class DistrictApplication:IDistrictApplication
    {  
        private readonly IDistrictDomain _districtDomain;

        public DistrictApplication(IDistrictDomain districtDomain)
        {
            _districtDomain = districtDomain;
        }

        public District GetDistrictByDistrictName(string districtName) => _districtDomain.GetDistrictByDistrictName(districtName);

        public District RetrieveDistrictByCountyName(string countyName) =>
            _districtDomain.RetrieveDistrictByCountyName(countyName);


    }
}
