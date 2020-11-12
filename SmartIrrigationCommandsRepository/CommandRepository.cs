using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIrrigationCommandsRepository
{
    public class CommandRepository
    {

        public static string GetCountiesCommand =
            "SELECT TOP (1) [CountyId],[Name], [Id_District] FROM [dbo].[Counties]";
    }
}
