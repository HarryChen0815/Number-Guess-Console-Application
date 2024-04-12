using System;

namespace NumberGuessConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int aim = random.Next(1, 100);
            int times = 0; 
            int guess;
            string input;
            string instruction;

            Console.WriteLine("Welcome to the Number Guess Console Application");
            Console.WriteLine("There is an expected value between 1 and 100. Please Guess it");
            Console.WriteLine(aim);

            while (true) {
                Console.WriteLine("Please enter your guess value");
                input = Console.ReadLine();

                if (!int.TryParse(input, out guess))
                {
                    Console.WriteLine("Please enter a valid format input.");
                    continue;
                }

                if (guess > 100 || guess < 1){
                    Console.WriteLine("Please enter a valid value between 1 and 100.");
                    continue;
                }

                times += 1;
                
                if (guess > aim){
                    Console.WriteLine("You value is higher than the expected, please try again.");
                }
                else if (guess < aim){
                    Console.WriteLine("You value is lower than the expected, please try again.");
                }
                else if (guess == aim){
                    Console.WriteLine("Congratulations! your value is the expected");
                    Console.WriteLine("You used " + times + " times to find the expected value");
                    Console.WriteLine("");
                    Console.WriteLine("Do you want to try it again? (Y/N)");

                    instruction = Console.ReadLine();
                    if(instruction.ToUpper() == "Y"){
                        aim = random.Next(1, 100);
                        times = 0;
                        Console.WriteLine("The new aim value was generated");
                        Console.WriteLine(aim);
                    }
                    else {
                        Console.WriteLine("End the game. Goodbye!");
                        break;
                    }      
                }
            }
        }
    }
}
