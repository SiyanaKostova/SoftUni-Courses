using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._List_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] tokens = command.Split();

                if (tokens[0] == "Add")
                {
                    int number = int.Parse(tokens[1]);
                    numbers.Add(number);
                }
                else if (tokens[0] == "Insert")
                {
                    int number = int.Parse(tokens[1]);
                    int index = int.Parse(tokens[2]);

                    if (index >= 0 && index < numbers.Count)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }

                    numbers.Insert(index, number);
                }
                else if (tokens[0] == "Remove")
                {
                    int index = int.Parse(tokens[1]);

                    if (index < 0 || index >= numbers.Count)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }

                    numbers.RemoveAt(index);
                }
                else if (tokens[0] == "Shift")
                {
                    int count = int.Parse(tokens[2]);

                    if (tokens[1] == "left")
                    {
                        for (int i = 0; i < count; i++)
                        {
                            numbers.Add(numbers[0]);
                            numbers.RemoveAt(0);
                        }
                    }
                    else if (tokens[1] == "right")
                    {
                        for (int i = 0; i < count; i++)
                        {
                            numbers.Insert(0, numbers[numbers.Count - 1]);
                            numbers.RemoveAt(numbers.Count - 1);
                        }
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
