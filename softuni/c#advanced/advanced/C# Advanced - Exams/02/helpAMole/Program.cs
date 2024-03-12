using System;
using System.Diagnostics;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            string[,] matrix = new string[size, size];

            int moleRow = 0;
            int moleCol = 0;

            bool isSFound = false;

            int firstSRow = 0;
            int firstSCol = 0;
            int secondSRow = 0;
            int secondSCol = 0;

            for (int row = 0; row < size; row++)
            {
                string data = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = data[col].ToString();

                    if (matrix[row, col] == "M")
                    {
                        moleRow = row;
                        moleCol = col;
                        matrix[row, col] = "-";
                    }
                    if (matrix[row, col] == "S")
                    {
                        if (!isSFound)
                        {
                            firstSRow = row;
                            firstSCol = col;
                            isSFound = true;
                        }
                        else
                        {
                            secondSRow = row;
                            secondSCol = col;
                        }
                    }
                }
            }
            string command = string.Empty;
            int points = 0;

            int previousRow = 0;
            int previousCol = 0;

            while (true)
            {
                command = Console.ReadLine();
                previousRow = moleRow;
                previousCol = moleCol;

                if (command == "End")
                {
                    break;
                }
                if (points >= 25)
                {
                    break;
                }

                switch (command)
                {
                    case "up":
                        moleRow--;
                        break;
                    case "down":
                        moleRow++;
                        break;
                    case "left":
                        moleCol--;
                        break;
                    case "right":
                        moleCol++;
                        break;
                }

                if (IsInside(moleRow, moleCol, size))
                {
                    if (matrix[moleRow, moleCol] == "S")
                    {
                        matrix[moleRow, moleCol] = "-";
                        points -= 3;

                        if (firstSRow == moleRow && firstSCol == moleCol)
                        {
                            moleRow = secondSRow;
                            moleCol = secondSCol;
                        }
                        else
                        {
                            moleRow = firstSRow;
                            moleCol = firstSCol;
                        }

                        matrix[moleRow, moleCol] = "-";
                    }
                    else if(matrix[moleRow, moleCol] != "M" && matrix[moleRow, moleCol] != "-")
                    {
                        points += int.Parse(matrix[moleRow, moleCol]);
                        matrix[moleRow, moleCol] = "-"; 
                    }
                }
                else
                {
                    moleRow = previousRow;
                    moleCol = previousCol;
                    Console.WriteLine("Don't try to escape the playing field!");
                    continue;
                }
            }

            if (points >= 25)
            {
                matrix[moleRow, moleCol] = "M";
                Console.WriteLine("Yay! The Mole survived another game!");
                Console.WriteLine($"The Mole managed to survive with a total of {points} points.");
            }
            else
            {
                matrix[moleRow, moleCol] = "M";
                Console.WriteLine("Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {points} points.");
            }

            PrintMatrix(matrix);

            static bool IsInside(int row, int col, int size)
            {
                return row >= 0 && row < size &&
                       col >= 0 && col < size;
            }
            static void PrintMatrix<T>(T[,] matrix)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        Console.Write($"{matrix[row, col]}");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}