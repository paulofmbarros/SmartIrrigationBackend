using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIrrigationModels.Models.DTOS
{
    public class Location
    {
        public int? Id_Location { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public string? Altitude { get; set; }
        public string? Description { get; set; }
        public int? Id_District { get; set; }
        public short? Id_Countie { get; set; }



        public Location(int? id_Location, string? latitude, string? longitude, string? altitude, string? description, int? id_District, short? id_Countie){
            Id_Location = id_Location;
            Latitude = latitude;
            Longitude = longitude;
            Altitude = altitude;
            Description = description;
            Id_Countie = id_Countie;
            Id_District = id_District;
        }


        public Location( string latitude, string longitude, string altitude, string description, int id_District, short id_Countie)
        {
           
            Latitude = latitude;
            Longitude = longitude;
            Altitude = altitude;
            Description = description;
            Id_Countie = id_Countie;
            Id_District = id_District;
        }

        public Location()
        {
                
        }
    }
}
