using System;
using Microsoft.Extensions.Configuration;

namespace NumberGuessConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {

            Setting setting = new Setting();
            var minRange = setting.MinRange;
            var maxRange = setting.MaxRange;
            // Print the values
            Console.WriteLine($"MinRange: {minRange}");
            Console.WriteLine($"MaxRange: {maxRange}");

            NumberGuessGame game = new NumberGuessGame(minRange, maxRange);
            game.Proceed();

        }
    }

    class Setting
    {
        public int MinRange { get; private set; }
        public int MaxRange { get; private set; }

        public Setting()
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
            MinRange = int.Parse(numberGuessSettings["MinRange"]);
            MaxRange = int.Parse(numberGuessSettings["MaxRange"]);
        }
    }


    class NumberGuessGame
    {
        private readonly int _minRange;
        private readonly int _maxRange;
        private readonly Random _random;

        public NumberGuessGame(int minRange, int maxRange)
        {
            _minRange = minRange;
            _maxRange = maxRange;
            _random = new Random();
        }

        public void Proceed()
        {
            int aim = _random.Next(_minRange, _maxRange);
            int times = 0;
            int guess;
            string input;
            string instruction;

            const string welcomeMessage = "Welcome to the Number Guess Console Application";
            string instructionMessage = $"There is an expected value between {_minRange} and {_maxRange}. Please guess it";
            string newInstructionMessage = $"The new aim value between {_minRange} and {_maxRange} was generated. Please guess it";
            string invalidNumberMessage = $"Please enter a valid value between {_minRange} and {_maxRange}.";
            const string remindInputMessage = "Please enter your guess value";
            const string invalidFormatMessage = "Please enter a valid format input.";
            const string higherHint = "You value is higher than the expected, please try again.";
            const string lowerHint = "You value is lower than the expected, please try again.";
            const string congratulations = "Congratulations! your value is the expected";
            const string playAgainMessage = "Do you want to try it again? (Y/N)";
            const string goodbyeMessage = "End the game. Goodbye!";

            Console.WriteLine(welcomeMessage);
            Console.WriteLine(instructionMessage);
            // Console.WriteLine(aim);

            while (true)
            {
                Console.WriteLine(remindInputMessage);
                input = Console.ReadLine();

                if (!int.TryParse(input, out guess))
                {
                    Console.WriteLine(invalidFormatMessage);
                    continue;
                }

                if (guess > _maxRange || guess < _minRange)
                {
                    Console.WriteLine(invalidNumberMessage);
                    continue;
                }

                times += 1;

                if (guess > aim)
                {
                    Console.WriteLine(higherHint);
                }
                else if (guess < aim)
                {
                    Console.WriteLine(lowerHint);
                }
                else if (guess == aim)
                {

                    Console.WriteLine(congratulations);
                    Console.WriteLine($"You used {times} times to find the expected value");
                    Console.WriteLine();
                    Console.WriteLine(playAgainMessage);

                    instruction = Console.ReadLine();
                    if (instruction.ToUpper() == "Y")
                    {
                        aim = _random.Next(_minRange, _maxRange);
                        times = 0;
                        Console.WriteLine(newInstructionMessage);
                        // Console.WriteLine(aim);
                    }
                    else
                    {
                        Console.WriteLine(goodbyeMessage);
                        break;
                    }
                }
            }
        }
    }
}
