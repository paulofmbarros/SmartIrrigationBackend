using System;
using System.Collections.Generic;
using System.Text;
using SmartIrrigation.Abstractions.Relational.Reads;

namespace SmartIrrigation.Domain.BasicCRUD.District
{
    public class DistrictDomain : IDistrictDomain
    {
        private readonly IReadDistrictInformation _readDistrictInformation;

        public DistrictDomain(IReadDistrictInformation readDistrictInformation)
        {
            _readDistrictInformation = readDistrictInformation;
        }

        public SmartIrrigationModels.Models.DTOS.District GetDistrictByDistrictName(string districtName) =>
            _readDistrictInformation.RetrieveDistrictByDistrictName(districtName);

        public SmartIrrigationModels.Models.DTOS.District RetrieveDistrictByCountyName(string countyName) =>
            _readDistrictInformation.RetrieveDistrictByCountyName(countyName);


    }
}
