using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Numbers
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<int> AboveAverage = new List<int>();

            double average = numbers.Average();
            int counter = 0;

            numbers.Sort();
            numbers.Reverse();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] > average)
                {
                    AboveAverage.Add(numbers[i]);
                    counter++;
                }
                if (counter == 5)
                {

                    break;

                }

            }
            if (counter == 0)
            {
                Console.WriteLine("No");
                return;
            }

            Console.WriteLine(string.Join(' ', AboveAverage));

        }
    }
}
