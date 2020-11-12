using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace SmartIrrigation.Abstractions.Relational.Configuration
{
    public class ConfigRelational :IConfigRelational
    {
        public string GetConnectionString()
        {
            var builder = new ConfigurationBuilder().SetBasePath(
                    Path.Combine(
                        Directory.GetParent(Directory.GetCurrentDirectory()).ToString(),
                        Assembly.GetExecutingAssembly().GetName().Name)
                )
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build().ToString();
        }
    }
}
