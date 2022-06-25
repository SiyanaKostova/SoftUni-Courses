using System;

namespace _01._Computer_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            double sumTaxes = 0;
            double sumWithoutTaxes = 0;
            double total = 0;

            while (command != "special" && command != "regular")
            {
                double partPrice = double.Parse(command);

                double tax = 0.2 * partPrice;


                if (partPrice < 0)
                {
                    Console.WriteLine("Invalid price!");
                }
                else
                {
                    sumTaxes += tax;
                    sumWithoutTaxes += partPrice;
                    
                }
                command = Console.ReadLine();
            }

            total = sumWithoutTaxes + sumTaxes;

            if (sumTaxes == 0)
            {
                Console.WriteLine("Invalid order!");
                return;
            }
            if (command == "special")
            {
                total *= 0.9;
            }

            Console.WriteLine($"Congratulations you've just bought a new computer!");
            Console.WriteLine($"Price without taxes: {sumWithoutTaxes:f2}$");
            Console.WriteLine($"Taxes: {sumTaxes:f2}$");
            Console.WriteLine($"-----------");
            Console.WriteLine($"Total price: {total:f2}$");
        }
    }
}
