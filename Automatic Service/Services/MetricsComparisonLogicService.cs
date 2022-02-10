using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartIrrigationModels.Models.DTOS;

namespace Automatic_Service.Services
{
    public class MetricsComparisonLogicService
    {
        public bool IsTheTemperatureOkToSprinkle(List<List<Read_Hourly>> read_Hourlies)
        {
            foreach (var activenode in read_Hourlies)
            {
                int avg = (int) activenode.Average(x => x.Temperature);
                Read_Hourly nearestReadValue = activenode.Where(x =>
                        x.DateReading.Hour == DateTime.Now.Hour || x.DateReading.Hour == DateTime.Now.Hour + 1)
                    .FirstOrDefault();

                
                //if the actual tempeature is more or less than 2 degrees of the avg than activate de IS
                if (nearestReadValue.Temperature <= avg + 3 || nearestReadValue.Temperature > avg - 3)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
