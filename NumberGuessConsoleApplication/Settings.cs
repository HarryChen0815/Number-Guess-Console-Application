using System;
using Microsoft.Extensions.Configuration;

namespace NumberGuessConsoleApplication
{
    // Setting class to retrieve configuration values
    public class Settings
    {
        private readonly IConfiguration _configuration;
        public Settings(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public SettingOptions GetOptions()
        {
            // Create a new configuration builder
            var builder = new ConfigurationBuilder();

            // Add the JSON file as configuration
            builder
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json");

            // Build the configuration
            var configuration = builder.Build();

            // Access the NumberGuessSettings section
            var numberGuessSettings = configuration.GetSection("NumberGuessSettings");

            // Access the MinRange and MaxRange values and store them in properties
            var minRange = int.Parse(numberGuessSettings["MinRange"]);
            var maxRange = int.Parse(numberGuessSettings["MaxRange"]);
            
            // Get the minRange and maxRange values from the Setting instance's properties
            return new SettingOptions(minRange, maxRange);
        }
    }
}