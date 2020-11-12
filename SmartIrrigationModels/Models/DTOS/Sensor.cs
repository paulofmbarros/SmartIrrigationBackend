using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIrrigationModels.Models.DTOS
{
    public class Sensor
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Id_Location { get; set; }
        public int Id_Node { get; set; }
        public bool Is_Enable { get; set; }
    }
}
