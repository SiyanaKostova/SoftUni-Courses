using System;
using System.Linq;
using System.Collections.Generic;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> clothes = new(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int rackCapacity = int.Parse(Console.ReadLine());
            int currentRackSize = rackCapacity;
            int numberOfRacks = 1;
            while (clothes.Any())
            {
                currentRackSize -= clothes.Peek();

                if (currentRackSize < 0)
                {
                    currentRackSize = rackCapacity;
                    numberOfRacks++;
                    continue;
                }
                clothes.Pop();
            }
            Console.WriteLine(numberOfRacks);
        }
    }
}