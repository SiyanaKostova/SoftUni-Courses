using System;

namespace Account_Balance
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double totalAmount = 0;

            while (input != "NoMoreMoney")
            {
                double currentAmount = double.Parse(input);
                if (currentAmount < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                totalAmount += currentAmount;
                Console.WriteLine($"Increase: {currentAmount:f2}");
                input = Console.ReadLine();
            }

            Console.WriteLine($"Total: {totalAmount:f2}");
        }
    }
}
