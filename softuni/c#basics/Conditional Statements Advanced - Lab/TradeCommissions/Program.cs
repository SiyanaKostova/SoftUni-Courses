using System;

namespace TradeCommissions
{
    class Program
    {
        static void Main(string[] args)
        {
            string town = Console.ReadLine();
            double percentageOfSales = double.Parse(Console.ReadLine());
            double comision = 0;
            if (town=="Sofia")
            {
                if (percentageOfSales>=0&&percentageOfSales<=500)
                {
                    comision = 0.05;
                }
                else if (percentageOfSales > 500 && percentageOfSales <= 1000)
                {
                    comision = 0.07;
                }
                else if (percentageOfSales > 1000 && percentageOfSales <= 10000)
                {
                    comision = 0.08;
                }
                else if (percentageOfSales > 10000)
                {
                    comision = 0.12;
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (town=="Varna")
            {
                if (percentageOfSales >= 0 && percentageOfSales <= 500)
                {
                    comision = 0.045;
                }
                else if (percentageOfSales > 500 && percentageOfSales <= 1000)
                {
                    comision = 0.075;
                }
                else if (percentageOfSales > 1000 && percentageOfSales <= 10000)
                {
                    comision = 0.10;
                }
                else if (percentageOfSales > 10000)
                {
                    comision = 0.13;
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (town == "Plovdiv")
            {
                if (percentageOfSales >= 0 && percentageOfSales <= 500)
                {
                    comision = 0.055;
                }
                else if (percentageOfSales > 500 && percentageOfSales <= 1000)
                {
                    comision = 0.08;
                }
                else if (percentageOfSales > 1000 && percentageOfSales <= 10000)
                {
                    comision = 0.12;
                }
                else if (percentageOfSales > 10000)
                {
                    comision = 0.145;
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else
            {
                Console.WriteLine("error");
            }
            double total = percentageOfSales * comision;
            if (comision!=0)
            {
                Console.WriteLine($"{total:f2}");
            }
        }
    }
}
