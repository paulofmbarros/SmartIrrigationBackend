﻿using System;
using System.Collections.Generic;
using System.Text;
using SmartIrrigationModels.Models.Geocoding;

namespace SmartIrrigation.Application.Node
{
    public interface INodeApplication
    {
        void AddNewNode(GeocodingAddressModelQueryParams address, bool isRealSensor,  bool isSprinkler, bool isEnable);
        SmartIrrigationModels.Models.DTOS.Node GetNodeByStreet(string street);
    }
}
