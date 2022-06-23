using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine().Split().Select(int.Parse).ToList();
            int maxCapacityOfWagon = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();

            while (command!="end")
            {
                string[] tokens = command.Split();

                if (tokens.Length == 2)
                {
                    int wagon = int.Parse(tokens[1]);
                    wagons.Add(wagon);  
                }
                else 
                {
                    int passengers = int.Parse(tokens[0]);
                    FindWagon(wagons, maxCapacityOfWagon, passengers);
                }

                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", wagons));
        }

        private static void FindWagon(List<int> wagons, int maxCapacityOfWagon, int passengers)
        {
            for (int i = 0; i < wagons.Count; i++)
            {
                int currentWagon = wagons[i];
                if (currentWagon + passengers <= maxCapacityOfWagon)
                {
                    wagons[i] += passengers;
                    break;
                }
            }
        }
    }
}
