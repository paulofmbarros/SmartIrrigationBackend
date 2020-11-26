using System;
using System.Collections.Generic;
using System.Text;
using SmartIrrigation.Abstractions.Relational.Creates;

namespace SmartIrrigation.Domain.Sensor
{
    public class SensorDomain :ISensorDomain
    {
        private readonly ISensorRepository _sensorRepository;

        public SensorDomain(ISensorRepository sensorRepository)
        {
            _sensorRepository = sensorRepository;
        }

        public int AddNewSensor(string Description, int? id_location, int Id_node, bool is_enable) =>
            _sensorRepository.AddNewSensor(Description, id_location, Id_node, is_enable);


    }
}
