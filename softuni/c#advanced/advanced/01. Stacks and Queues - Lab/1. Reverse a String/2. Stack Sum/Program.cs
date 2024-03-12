using System;
using System.Linq;
using System.Collections.Generic;

namespace Stack_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            Stack<int> stack = new Stack<int>(input);

            string command = Console.ReadLine().ToLower();

            while (command != "end")
            {
                string[] splitedCommand = command.Split();

                if (splitedCommand[0].ToLower() == "add")
                {
                    int first = int.Parse(splitedCommand[1]);
                    int second = int.Parse(splitedCommand[2]);

                    stack.Push(first);
                    stack.Push(second);
                }
                if (splitedCommand[0].ToLower() == "remove")
                {
                    int n = int.Parse(splitedCommand[1]);
                    if (n <= stack.Count)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            stack.Pop();
                        }
                    }     
                }
                command = Console.ReadLine().ToLower();
            }

            Console.WriteLine($"Sum: {stack.Sum()}");

        }
    }
}