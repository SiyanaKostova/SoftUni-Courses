using System;
using System.Linq;
using System.Collections.Generic;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> charsCount = new SortedDictionary<char, int>();

            string input = Console.ReadLine();

            foreach (var symbol in input)
            {
                if (!charsCount.ContainsKey(symbol))
                {
                    charsCount.Add(symbol, 0);
                }
                charsCount[symbol]++;
            }
            foreach (var ch in charsCount)
            {
                Console.WriteLine($"{ch.Key}: {ch.Value} time/s");
            }
        }
    }
}