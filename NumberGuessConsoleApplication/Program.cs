using System;
using Microsoft.Extensions.Configuration;

namespace NumberGuessConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new instance of Setting to retrieve configuration values
            Setting setting = new Setting();
            var options = setting.GetOptions();

            // Initialize the NumberGuessGame with minRange and maxRange values
            NumberGuessGame game = new NumberGuessGame(options);
            game.Proceed();
        }
    }
}