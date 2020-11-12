using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIrrigationModels.Models.DTOS
{
    public class Station
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Regional { get; set; }
        public string National { get; set; }
        public int Wmo { get; set; }
        public string Icao { get; set; }
        public string Iata { get; set; }
        public int Elevation { get; set; }
        public string Timezone { get; set; }
        public bool Active { get; set; }
        public int Id_Location { get; set; }
    }
}
