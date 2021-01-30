using System;
using System.Collections.Generic;
using System.Text;
using SmartIrrigationModels.Models;
using SmartIrrigationModels.Models.WeatherData;

namespace SmartIrrigation.Abstractions.Relational.Creates
{
    public interface IReadHourlyRepository
    {
        int AddReadHourly(RootWeatherDataModel<HourlyDataModel> rootWeatherDataModel, bool isStation, int? idStation, int IdNode);
    }
}
