using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Tasks
{
    public class Config
    {
        public bool UseSql { get; set; }
        public string ConnectionString { get; set; }
        public string FilePath { get; set; } = "";

        public Config(string configFile)
        {
            UseSql = true;

            // Look for a DB connectionstring
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(configFile, optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            ConnectionString = configuration.GetConnectionString("Tasks");
            if (ConnectionString == null || ConnectionString.Trim().Length == 0)
            {
                // No connection string, use file path
                UseSql = false;
                FilePath = configuration.GetSection("File")["Tasks"];
            }
        }
    }
}
