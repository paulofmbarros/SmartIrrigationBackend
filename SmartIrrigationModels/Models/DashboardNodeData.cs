using System;
using System.Collections.Generic;
using System.Text;
using SmartIrrigationModels.Models.DTOS;

namespace SmartIrrigationModels.Models
{
    public class DashboardNodeData
    {
        public Node Node { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string County { get; set; }
        public string DistrictName { get; set; }
    }
}
