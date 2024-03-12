using System;
using System.Linq;
using System.Collections.Generic;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string word = Console.ReadLine();

            int rows = int.Parse(size[0]);
            int cols = int.Parse(size[1]);

            char[,] matrix = new char[rows, cols];

            int currentWordIndex = 0;

            for (int row = 0; row < rows; row++)
            {
                if (row%2 == 0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (currentWordIndex == word.Length)
                        {
                            currentWordIndex = 0;
                        }

                        matrix[row, col] = word[currentWordIndex];
                        currentWordIndex++;
                    }
                }
                else
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        if (currentWordIndex == word.Length)
                        {
                            currentWordIndex = 0;
                        }
                        matrix[row, col] = word[currentWordIndex];
                        currentWordIndex++;
                    }
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write($"{matrix[row,col]}");
                }
                Console.WriteLine();
            }
        }
    }
}