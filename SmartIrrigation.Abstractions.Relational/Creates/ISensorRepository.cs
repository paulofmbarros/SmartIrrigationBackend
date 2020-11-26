using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIrrigation.Abstractions.Relational.Creates
{
    public interface ISensorRepository
    {
        int AddNewSensor(string description, int? idLocation, in int idNode, in bool isEnable);
    }
}
