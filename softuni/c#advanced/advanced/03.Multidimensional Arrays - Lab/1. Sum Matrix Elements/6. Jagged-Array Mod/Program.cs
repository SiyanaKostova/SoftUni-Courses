using System;
using System.Linq;
using System.Collections.Generic;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] jaggedArray = new int[rows][];

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                jaggedArray[row] = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }

            string command = Console.ReadLine().ToLower();

            while (command != "end")
            {
                string[] splittedCommand = command.Split();

                string operation = splittedCommand[0];
                int row = int.Parse(splittedCommand[1]);
                int col = int.Parse(splittedCommand[2]);
                int value = int.Parse(splittedCommand[3]);

                if (row < 0 || row >= jaggedArray.Length || col < 0 || col >= jaggedArray[row].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                }
                else
                {
                    switch (operation)
                    {
                        case "add":
                            jaggedArray[row][col] += value;
                            break;
                        case "subtract":
                            jaggedArray[row][col] -= value;
                            break;
                    }
                }
                command = Console.ReadLine().ToLower();
            }

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    Console.Write($"{jaggedArray[row][col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}