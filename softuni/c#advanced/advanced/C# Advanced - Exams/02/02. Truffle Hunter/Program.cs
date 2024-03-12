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

            string[,] forest = new string[size, size];

            for (int row = 0; row < size; row++)
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < size; col++)
                {
                    forest[row, col] = data[col];
                }
            }

            string command = Console.ReadLine();

            int BlackTruffleCounter = 0;
            int SummerTruffleCounter = 0;
            int WhiteTruffleCounter = 0;

            int wildBoarTruffles = 0;

            while (command != "Stop the hunt")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string currCommand = tokens[0];

                if (currCommand == "Collect")
                {
                    int currRow = int.Parse(tokens[1]);
                    int currCol = int.Parse(tokens[2]);

                    if (forest[currRow, currCol] == "B")
                    {
                        BlackTruffleCounter++;
                        forest[currRow, currCol] = "-";
                    }
                    else if (forest[currRow, currCol] == "S")
                    {
                        SummerTruffleCounter++;
                        forest[currRow, currCol] = "-";
                    }
                    else if (forest[currRow, currCol] == "W")
                    {
                        WhiteTruffleCounter++;
                        forest[currRow, currCol] = "-";
                    }
                }

                else if (currCommand == "Wild_Boar")
                {
                    int row = int.Parse(tokens[1]);
                    int col = int.Parse(tokens[2]);
                    string direction = tokens[3];

                    if (direction == "up")
                    {
                        for (int i = row; i >= 0; i -= 2)
                        {
                            if (forest[i, col] != "-")
                            {
                                wildBoarTruffles++;
                                forest[i, col] = "-";

                            }
                        }
                    }
                    else if (direction == "down")
                    {
                        for (int i = row; i < size; i += 2)
                        {
                            if (forest[i, col] != "-")
                            {
                                wildBoarTruffles++;
                                forest[i, col] = "-";

                            }
                        }
                    }
                    else if (direction == "left")
                    {
                        for (int i = col; i >= 0; i -= 2)
                        {
                            if (forest[row, i] != "-")
                            {
                                wildBoarTruffles++;
                                forest[row, i] = "-";
                            }
                        }
                    }
                    else if (direction == "right")
                    {
                        for (int i = col; i < size; i += 2)
                        {
                            if (forest[row, i] != "-")
                            {
                                wildBoarTruffles++;
                                forest[row, i] = "-";
                            }
                        }
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Peter manages to harvest {BlackTruffleCounter} black, {SummerTruffleCounter} summer, and {WhiteTruffleCounter} white truffles.");
            Console.WriteLine($"The wild boar has eaten {wildBoarTruffles} truffles.");

            PrintMatrix(forest);

            static void PrintMatrix<T>(T[,] matrix)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        Console.Write($"{matrix[row, col]} ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}