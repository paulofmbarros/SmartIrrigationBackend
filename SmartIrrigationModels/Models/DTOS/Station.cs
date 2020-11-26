using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIrrigationModels.Models.DTOS
{
    public class Station
    {
        public int? Id_Station { get; set; }
        public string? Name { get; set; }
        public string? Country { get; set; }
        public string? Regional { get; set; }
        public string? National { get; set; }
        public int? Wmo { get; set; }
        public string? Icao { get; set; }
        public string? Iata { get; set; }
        public int? Elevation { get; set; }
        public string? Timezone { get; set; }
        public bool? Active { get; set; }
        public int? Id_Location { get; set; }






        public Station(int? id_Station, string? name, string? country, string? regional, string? national, int? wmo, string? icao, string? iata, int? elevation, string? timezone, bool? active, int? id_Location)
        {
            Id_Station = id_Station;
            Name = name;
            Country = country;
            Regional = regional;
            National = national;
            Wmo = wmo;
            Icao = icao;
            Iata = iata;
            Elevation = elevation;
            Timezone = timezone;
            Active = active;
            Id_Location = id_Location;
        }
    }
}
