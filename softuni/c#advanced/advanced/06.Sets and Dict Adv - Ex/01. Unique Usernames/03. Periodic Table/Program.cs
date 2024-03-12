using System;
using System.Linq;
using System.Collections.Generic;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfElements = int.Parse(Console.ReadLine());
            SortedSet<string> elements = new SortedSet<string>();

            for (int i = 0; i < countOfElements; i++)
            {
                string[] input = Console.ReadLine().Split();
                elements.UnionWith(input);
            }

            Console.WriteLine(string.Join(" ", elements));
        }
    }
}