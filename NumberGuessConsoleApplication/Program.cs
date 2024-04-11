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

            Console.WriteLine("Welcome to the Number Guess Console Application");
            Console.WriteLine("There is an expected value between 1 and 100. Please Guess it");
            Console.WriteLine(aim);

            while (true) {
                Console.WriteLine("Enter your guess value (or 'Esc' to end, or 'Re' to generate another value)");
                string input = Console.ReadLine();

                if(input == "Esc"){
                    Console.WriteLine("End the application. Goodbye!");
                    break;
                }
                if(input == "Re"){
                    int aim1 = random.Next(1, 100);
                    aim = aim1;
                    times = 0;
                    Console.WriteLine("The new aim value was generated");
                    Console.WriteLine(aim);
                    continue;
                }
                if (input == aim.ToString()){
                    Console.WriteLine("Congratulations! your value is the expected");
                    Console.WriteLine("You used " + times + " times to find the expected value");
                }
            }

        }
    }
}
