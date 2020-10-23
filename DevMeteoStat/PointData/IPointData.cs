using System;
using System.Collections.Generic;
using System.Text;
using SmartIrrigationModels.Models;
using SmartIrrigationModels.Models.WeatherData;

namespace DevMeteoStat
{
    public interface IPointData
    {
        RootWeatherDataModel<HourlyDataModel> GetHourlyDataOfPoint(HourlyDataOfAPointQueryParams hourlyDataOfAPointParams);
        RootWeatherDataModel<DailyDataModel> DailyDataOfAPoint(DailyDataOfAPointQueryParams dailyDataOfAPointParams);
        RootWeatherDataModel<ClimateNormalsOfAPointDataModel> ClimateNormalsOfAPoint(float lat, float lon, int alt);
    }
}
