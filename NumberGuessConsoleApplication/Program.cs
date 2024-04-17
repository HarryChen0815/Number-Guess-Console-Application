using System;

namespace NumberGuessConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int minRange = 1;
            int maxRange = 100;

            NumberGuessGame game = new NumberGuessGame(minRange, maxRange);
            game.Proceed();
            
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
            Console.WriteLine(aim);

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
                        Console.WriteLine(aim);
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
