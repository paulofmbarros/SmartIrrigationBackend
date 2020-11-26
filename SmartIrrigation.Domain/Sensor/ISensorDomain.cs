using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIrrigation.Domain.Sensor
{
    public interface ISensorDomain
    {
        int AddNewSensor(string Description, int? id_location, int Id_node, bool is_enable);
    }
}
