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
            int[,] matrix = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                int[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = data[col];
                }
            }

            int sumOfPrimaryDiagonal = 0;
            int sumOfSecondaryDiagonal = 0;

            for (int i = 0; i < size; i++)
            {
                sumOfPrimaryDiagonal += matrix[i, i];
                sumOfSecondaryDiagonal += matrix[i, size - 1 - i];
            }

            Console.WriteLine(Math.Abs(sumOfSecondaryDiagonal - sumOfPrimaryDiagonal));
        }
    }
}