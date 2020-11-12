using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIrrigationModels.Models.DTOS
{
    public class County
    {
        public int CountyId { get; set; }
        public string Name { get; set; }

        public int Id_District { get; set; }
    }
}
