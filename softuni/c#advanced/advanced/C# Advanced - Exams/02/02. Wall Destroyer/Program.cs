using System;
using System.Linq;
using System.Collections.Generic;

namespace MyApp 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            string[,] matrix = new string[size, size];

            int vankoRow = 0;
            int vankoCol = 0;

            for (int row = 0; row < size; row++)
            {
                string data = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = data[col].ToString();

                    if (matrix[row, col] == "V")
                    {
                        matrix[row, col] = "*";
                        vankoRow = row;
                        vankoCol = col;
                    }
                }
            }

            string command = string.Empty;
            int countOfHoles = 1;
            int countOfRods = 0;
            bool isKilled = false;

            while (true)
            {
                command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                int previousRow = vankoRow;
                int previousCol = vankoCol;

                switch (command)
                {
                    case "up":
                        if ((vankoRow - 1) >= 0)
                        {
                            vankoRow--;
                        }
                        else
                        {
                            continue;
                        }
                        break;

                    case "down":
                        if (vankoRow + 1 < size)
                        {
                            vankoRow++;
                        }
                        else
                        {
                            continue;
                        }
                        break;

                    case "left":
                        if ((vankoCol - 1) >= 0)
                        {
                            vankoCol--;
                        }
                        else
                        {
                            continue;
                        }
                        break;

                    case "right":
                        if (vankoCol + 1 < size)
                        {
                            vankoCol++;
                        }
                        else
                        {
                            continue;
                        }
                        break;
                }

                if (matrix[vankoRow, vankoCol] == "C")
                {
                    matrix[vankoRow, vankoCol] = "E";
                    countOfHoles++;
                    isKilled = true;
                    break;
                }
                else if (matrix[vankoRow, vankoCol] == "R")
                {
                    vankoRow = previousRow;
                    vankoCol = previousCol;
                    countOfRods++;
                    Console.WriteLine("Vanko hit a rod!");
                    continue;
                }
                else if (matrix[vankoRow, vankoCol] == "*")
                {
                    Console.WriteLine($"The wall is already destroyed at position [{vankoRow}, {vankoCol}]!");
                }
                else 
                {
                    countOfHoles++;
                    matrix[vankoRow, vankoCol] = "*";
                }

            }

            if (!isKilled)
            {
                Console.WriteLine($"Vanko managed to make {countOfHoles} hole(s) and he hit only {countOfRods} rod(s).");
            }
            else
            {
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {countOfHoles} hole(s).");
            }

            if (!isKilled)
            {
                matrix[vankoRow, vankoCol] = "V";
            }

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }
        }
    }
}