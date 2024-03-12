using System;
using System.Linq;
using System.Collections.Generic;

namespace MyApp 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

            Dictionary<double, int> occurances = new Dictionary<double, int>();

            foreach (var number in input)
            {
                if (!occurances.ContainsKey(number))
                {
                    occurances.Add(number, 0);
                }
                occurances[number]++;
            }

            foreach (var occurance in occurances)
            {
                Console.WriteLine($"{occurance.Key} - {occurance.Value} times");
            }
        }
    }
}
