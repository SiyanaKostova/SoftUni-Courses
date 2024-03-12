using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int numbersToEnqueue = tokens[0];
            int numbersToDequeue = tokens[1];
            int number = tokens[2];

            Queue<int> queue = new Queue<int>();    

            for (int i = 0; i < numbersToEnqueue; i++)
            {
                queue.Enqueue(numbers[i]);
            }
            for (int i = 0; i < numbersToDequeue; i++)
            {
                queue.Dequeue();
            }
            if (queue.Contains(number))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (queue.Any())
                {
                    Console.WriteLine(queue.Min());
                }
                else
                {
                    Console.WriteLine(0);
                }
            }
        }
    }
}