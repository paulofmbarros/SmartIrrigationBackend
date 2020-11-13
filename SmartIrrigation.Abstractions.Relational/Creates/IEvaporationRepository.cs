using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIrrigation.Abstractions.Relational.Creates
{
    public interface IEvaporationRepository
    {
        int InsertEvaporationData(string[] lines, int Id_District);
    }
}
