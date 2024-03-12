using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate<string> filterByUpperCase = s => s[0] == char.ToUpper(s[0]);
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Where(w => filterByUpperCase(w)).ToArray();
            foreach (var item in input)
            {
                Console.WriteLine(item);
            }
        }
    }
}