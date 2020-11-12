using System;
using System.Collections.Generic;
using System.Text;
using SmartIrrigationModels.Models.DTOS;

namespace IpmaAPI
{
    public interface IIpmaDataRequisitions
    {
        string[] GetHistoryEvaporationByCountyName(County county, string districtName);
    }
}
