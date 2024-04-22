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

            // Get the minRange and maxRange values from the Setting instance's properties
            var minRange = setting.MinRange;
            var maxRange = setting.MaxRange;

            // Initialize the NumberGuessGame with minRange and maxRange values
            NumberGuessGame game = new NumberGuessGame(minRange, maxRange);
            game.Proceed();
        }
    }

    // Setting class to retrieve configuration values
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


    // NumberGuessGame class to proceed game 
    class NumberGuessGame
    {
        // Fields to store the minimum and maximum range of the game and a Random object
        private readonly int _minRange;
        private readonly int _maxRange;
        private readonly Random _random;

        // Constructor to initialize the game with the specified range
        public NumberGuessGame(int minRange, int maxRange)
        {
            _minRange = minRange;
            _maxRange = maxRange;
            _random = new Random();
        }

        // Method to start the game
        public void Proceed()
        {
            // Generate a random number within the specified range
            int aim = _random.Next(_minRange, _maxRange);
            // Initialize a counter to track the number of guesses
            int times = 0;
            // Variables to store user input, game instruction and guess value
            string input;
            string instruction;

            // Constant messages used throughout the game
            const string welcomeMessage = "Welcome to the Number Guess Console Application";
            string instructionMessage = $"There is an expected value between {_minRange} and {_maxRange}. Please guess it";
            string invalidNumberMessage = $"Please enter a valid value between {_minRange} and {_maxRange}.";
            const string remindInputMessage = "Please enter your guess value";
            const string invalidFormatMessage = "Please enter a valid format input.";
            const string higherHint = "You value is higher than the expected, please try again.";
            const string lowerHint = "You value is lower than the expected, please try again.";
            const string congratulations = "Congratulations! your value is the expected";
            const string playAgainMessage = "Do you want to try it again? (Y/N)";
            const string goodbyeMessage = "End the game. Goodbye!";

            // Display welcome message and initial instruction
            Console.WriteLine(welcomeMessage);
            Console.WriteLine(instructionMessage);

            // Main game loop
            while (true)
            {
                // Prompt the user to enter their guess
                Console.WriteLine(remindInputMessage);
                input = Console.ReadLine();

                // Validate user input format
                if (!int.TryParse(input, out int guess))
                {
                    Console.WriteLine(invalidFormatMessage);
                    continue;
                }

                // Validate if the guess is within the valid range
                if (guess > _maxRange || guess < _minRange)
                {
                    Console.WriteLine(invalidNumberMessage);
                    continue;
                }

                // Increment the guess counter if the guess follow the format and be within the valid range
                times += 1;

                // Provide hints based on the user's guess compared to the expected value
                if (guess > aim)
                {
                    Console.WriteLine(higherHint);
                }
                else if (guess < aim)
                {
                    Console.WriteLine(lowerHint);
                }
                else if (guess == aim) // Player has guessed the correct number
                {
                    // Display congratulations message and the number of attempts
                    Console.WriteLine(congratulations);
                    Console.WriteLine($"You used {times} times to find the expected value");
                    Console.WriteLine();
                    Console.WriteLine(playAgainMessage);

                    // Prompt the player if they want to play again
                    instruction = Console.ReadLine();
                    if (instruction.ToUpper() == "Y") // Player wants to play again
                    {
                        // Generate a new random number and reset the guess counter
                        aim = _random.Next(_minRange, _maxRange);
                        times = 0;
                        // Display the new instruction with the updated aim value
                        Console.WriteLine(instructionMessage);
                    }
                    else // Player chooses to end the game
                    {
                        Console.WriteLine(goodbyeMessage);
                        break; // Exit the game loop
                    }
                }
            }
        }
    }
}