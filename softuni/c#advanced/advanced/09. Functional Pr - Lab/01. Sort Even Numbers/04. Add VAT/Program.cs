using System;
using System.Linq;
using System.Collections.Generic;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] prices = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).Select(n => n * 1.2).ToArray();
            foreach (var item in prices)
            {
                Console.WriteLine($"{item:f2}");
            }
        }
    }
}