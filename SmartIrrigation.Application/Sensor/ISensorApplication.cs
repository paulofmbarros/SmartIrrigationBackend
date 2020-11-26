using System;
using System.Collections.Generic;
using System.Text;
using SmartIrrigationModels.Models.Geocoding;

namespace SmartIrrigation.Application.Sensor
{
    public interface ISensorApplication
    {
        int AddNewSensor(GeocodingAddressModelQueryParams address, in bool isEnable);
    }
}
