using System;
using System.Collections.Generic;
using System.Text;
using SmartIrrigationModels.Models.DTOS;

namespace SmartIrrigation.Abstractions.Relational.Creates
{
    public interface IWeatherStationRepository
    {
        void AddWeatherStationToDatabase(Station station);
    }
}
