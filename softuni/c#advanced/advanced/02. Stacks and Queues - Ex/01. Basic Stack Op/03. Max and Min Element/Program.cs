using System;
using System.Linq;
using System.Collections.Generic;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine()); 
            Stack<int> numbers = new Stack<int>();

            for (int i = 0; i < count; i++)
            {
                int[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                switch (tokens[0])
                {
                    case 1:
                        int number = tokens[1];
                        numbers.Push(number); 
                        break;
                    case 2:
                        if (numbers.Any())
                        {
                            numbers.Pop();
                        }
                        break;
                    case 3:
                        if (numbers.Any())
                        {
                            Console.WriteLine(numbers.Max());
                        }
                        break;
                    case 4:
                        if (numbers.Any())
                        {
                            Console.WriteLine(numbers.Min());
                        }
                        break;
                }
            }
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}