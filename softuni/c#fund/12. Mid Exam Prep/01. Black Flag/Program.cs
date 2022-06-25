using System;

namespace _01._Black_Flag
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double quantityForOneDay = double.Parse(Console.ReadLine());
            double expectedPlunders = double.Parse(Console.ReadLine());

            double sum = 0;
            double additional = 0.5 * quantityForOneDay;

            for (int i = 1; i <= days; i++)
            {
                sum += quantityForOneDay;

                if (i % 3 == 0)
                {
                    sum += additional;
                }
                if (i % 5 == 0)
                {
                    sum *= 0.7;
                }
            }

            if (sum >= expectedPlunders)
            {
                Console.WriteLine($"Ahoy! {sum:f2} plunder gained.");
            }
            else
            {
                double percentage = (sum / expectedPlunders) * 100;
                Console.WriteLine($"Collected only {percentage:f2}% of the plunder.");
            }
        }
    }
}
