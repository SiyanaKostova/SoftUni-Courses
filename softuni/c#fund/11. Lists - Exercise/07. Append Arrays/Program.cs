using System;
using System.Linq;
using System.Collections.Generic;

namespace _07._Append_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbersAsString = Console.ReadLine().Split('|').Reverse().ToList();
            var numbers = new List<int>();
            foreach (var number in numbersAsString)
            {
                numbers.AddRange(number.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
