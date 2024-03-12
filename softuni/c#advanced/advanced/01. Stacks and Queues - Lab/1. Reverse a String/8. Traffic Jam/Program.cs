using System;
using System.Collections.Generic;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> cars = new Queue<string>();
            int numberOfCars = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            int count = 0;

            while (command != "end")
            {
                if (command == "green")
                {
                    for (int i = 0; i < numberOfCars; i++)
                    {
                        if (cars.Count == 0)
                        {
                            break;
                        }
                        count++;
                        Console.WriteLine($"{cars.Dequeue()} passed!");
                    }
                }
                else
                {
                    cars.Enqueue(command);
                }
                command = Console.ReadLine();
            }

            Console.WriteLine($"{count} cars passed the crossroads.");
        }
    }
}