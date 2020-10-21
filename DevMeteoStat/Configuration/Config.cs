using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace DevMeteoStat.Configuration
{
    public static class Config 
    {
        
        private static readonly IConfiguration configuration;
        static Config()
        {
            var builder = new ConfigurationBuilder().SetBasePath(
                    Path.Combine(
                        Directory.GetParent(Directory.GetCurrentDirectory()).ToString(), 
                        Assembly.GetExecutingAssembly().GetName().Name)
                                )
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            configuration = builder.Build();
        }

        public static string GetConfiguration(string name)
        {
            string appSettings = configuration[name];
            return appSettings;
        }


    }
}
