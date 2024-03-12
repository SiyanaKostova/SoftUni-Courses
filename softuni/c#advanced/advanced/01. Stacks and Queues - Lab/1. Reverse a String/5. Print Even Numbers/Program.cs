using System;
using System.Collections.Generic;
using System.Linq;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] %2 == 0)
                {
                    queue.Enqueue(array[i]);
                }
            }
            Console.WriteLine(string.Join(", ", queue));
        }
    }
}