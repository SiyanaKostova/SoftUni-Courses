using System;

namespace _11._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfOrders = int.Parse(Console.ReadLine());
            double total = 0;

            for (int i = 0; i < numberOfOrders; i++)
            {
                double pricePerCapsule = double.Parse(Console.ReadLine());
                int days = int.Parse(Console.ReadLine());
                int capsulesCount = int.Parse(Console.ReadLine());
                double orderPrice = days * capsulesCount * pricePerCapsule;
                Console.WriteLine($"The price for the coffee is: ${orderPrice:f2}");
                total += orderPrice; 
            }
            Console.WriteLine($"Total: ${total:f2}");
            
        }
    }
}
