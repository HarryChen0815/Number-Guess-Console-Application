using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace NumberGuessConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set up DependencyInjection
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            // Start the game
            var game = serviceProvider.GetService<NumberGuessGame>();
            game?.Proceed();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            // Build configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Register configuration
            services.AddSingleton<IConfiguration>(configuration);

            // Register settings
            services.AddSingleton<Settings>();
            services.AddTransient(sp => sp.GetService<Settings>().GetOptions());

            // Register game
            services.AddTransient<NumberGuessGame>();
        }
    }
}