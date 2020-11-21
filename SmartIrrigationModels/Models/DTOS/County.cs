using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIrrigationModels.Models.DTOS
{
    public class County
    {
        public short CountyId { get; set; }
        public string Name { get; set; }

        public int Id_District { get; set; }
    }
}
