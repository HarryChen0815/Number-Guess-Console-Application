using System;

namespace NumberGuessConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int aim = random.Next(1, 100);
            // int times = 0; 

            Console.WriteLine("Welcome to the Number Guess Console Application");
            Console.WriteLine("There is an expected value between 1 and 100. Please Guess it");
            Console.WriteLine(aim);
        }
    }
}
