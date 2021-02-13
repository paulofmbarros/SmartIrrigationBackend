using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIrrigation.Abstractions.Relational.Creates
{
    public interface ISensorRepository
    {
        int AddNewSensor(string description, int? idLocation, in int idNode, in bool isEnable);

        int AddNewSensor(string description, string type, int IdLocation);
    }
}
