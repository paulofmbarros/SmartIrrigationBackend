using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIrrigation.Abstractions.Relational.Configuration
{
    public interface IConfigRelational
    {
        string GetConnectionString(string name);
    }
}
