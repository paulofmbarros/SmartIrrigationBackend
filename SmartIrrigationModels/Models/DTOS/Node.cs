using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIrrigationModels.Models.DTOS
{
    public class Node
    {
        public int IdNode { get; set; }
        public string Description { get; set; }
        public int IdLocation { get; set; }
        public int IdNearStation { get; set; }
        public bool IsEnable { get; set; }
        public bool IsRealSensor { get; set; }
        public bool IsSprinklerON { get; set; }
        public bool IsLightOn { get; set; }
        public bool IsSecurityCameraOn { get; set; }
    }
}
