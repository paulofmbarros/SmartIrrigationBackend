using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIrrigationModels.Models
{
    public class FindStationModel
    {
        public string Query { get; set; }
        public int? Limit { get; set; } = 8;
    }
}
