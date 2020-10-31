using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace SmartIrrigationConfigurationService
{
    public class Config :IConfig
    {
        private  readonly IConfiguration configuration;
        public Config()
        {
            var builder = new ConfigurationBuilder().SetBasePath(
                    Path.Combine(
                        Directory.GetParent(Directory.GetCurrentDirectory()).ToString(),
                        Assembly.GetExecutingAssembly().GetName().Name)
                )
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            configuration = builder.Build();
        }

        public string GetConfiguration(string name)
        {
            string appSettings = configuration[name];
            return appSettings;
        }
    }
}
