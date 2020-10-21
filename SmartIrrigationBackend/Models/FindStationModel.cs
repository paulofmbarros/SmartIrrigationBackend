using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartIrrigationBackend.Models
{
    public class FindStationModel
    {
        public string Query { get; set; }
        public int? Limit { get; set; } = 8;
    }
}
