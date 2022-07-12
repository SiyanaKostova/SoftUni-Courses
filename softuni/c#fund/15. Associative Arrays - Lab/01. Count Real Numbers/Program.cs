using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Real_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<int, int> countsByNumber = new SortedDictionary<int, int>();

            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            foreach (var number in numbers)
            {
                if (!countsByNumber.ContainsKey(number))
                {
                    countsByNumber.Add(number, 0);
                }
                countsByNumber[number]++;
            }

            foreach (var countByNumber in countsByNumber)
            {
                Console.WriteLine($"{countByNumber.Key} -> {countByNumber.Value}");
            }
        }
    }
}
