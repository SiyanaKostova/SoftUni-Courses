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
            int rows = int.Parse(size[0]);
            int cols = int.Parse(size[1]);

            char[,] matrix = new char[rows, cols];
            int countOfSquares = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row,col] = data[col];
                }
            }

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    if (matrix[row,col] == matrix[row, col + 1] 
                        && matrix[row, col] == matrix[row + 1, col + 1]
                        && matrix[row, col] == matrix[row + 1, col])
                    {
                        countOfSquares++;
                    }
                }
            }
            
                Console.WriteLine(countOfSquares);
            
        }
    }
}