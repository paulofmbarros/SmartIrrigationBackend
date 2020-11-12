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
        private readonly IConfiguration configuration;

        public ConfigRelational()
        {
            var builder = new ConfigurationBuilder().SetBasePath(
                    Path.Combine(
                        Directory.GetParent(Directory.GetCurrentDirectory()).ToString(),
                        Assembly.GetExecutingAssembly().GetName().Name)
                )
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            configuration = builder.Build();
        }
        public string GetConnectionString(string name)
        {
            string appSettings = configuration[name];
            return appSettings;
        }
    }
}
