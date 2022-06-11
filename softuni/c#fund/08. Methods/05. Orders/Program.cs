using System;

namespace _05._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            Orders(product, quantity);
        }
        static void Orders(string product, int quantity)
        {
            double result = 0.0;
            switch (product)
            {
                case "coffee":
                    result = 1.50 * quantity;
                    break;
                case "water":
                    result = 1.00 * quantity;
                    break;
                case "coke":
                    result = 1.40 * quantity;
                    break;
                case "snacks":
                    result = 2.00 * quantity;
                    break;
                default:
                    break;
            }
            Console.WriteLine($"{result:f2}");
        }
    }
}
