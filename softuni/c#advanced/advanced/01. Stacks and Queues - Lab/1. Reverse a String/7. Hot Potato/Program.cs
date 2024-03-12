using System;
using System.Collections.Generic;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] children = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Queue<string> queue = new Queue<string>(children);
            int n = int.Parse(Console.ReadLine());
            int tosses = 1;

            while (queue.Count != 1)
            {
                string child = queue.Dequeue();
                if (tosses < n)
                {
                    tosses++;
                    queue.Enqueue(child);
                }
                else
                {
                    Console.WriteLine($"Removed {child}");
                    tosses = 1;
                }
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}