using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIrrigationConfigurationService
{
    public interface IConfig
    {
        string GetConfiguration(string name);
    }
}
