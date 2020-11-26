using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIrrigationModels.Models.DTOS
{
    public class Node
    {
        public int Id_Node { get; set; }
        public string Description { get; set; }
        public int Id_Location { get; set; }
        public int Id_NearStation { get; set; }
        public bool Is_Enable { get; set; }
        public bool Is_RealSensor { get; set; }
        public bool Is_Sprinkler { get; set; }
    }
}
