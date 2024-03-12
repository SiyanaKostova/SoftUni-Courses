using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

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

            static void PrintError()
            {
                Console.WriteLine("Don't try to escape the playing field!");
            }

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
                        matrix[moleRow, moleCol] = "-";
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

            while ((command = Console.ReadLine()) != "End")
            {
                if (points >= 25)
                {
                    break;
                }

                if (command == "left")
                {
                    if ((moleCol - 1) >= 0)
                    {
                        moleCol--;
                    }
                    else
                    {
                        PrintError();
                        continue;
                    }
                }
                else if (command == "right")
                {
                    if ((moleCol + 1) < size)
                    {
                        moleCol++;
                    }
                    else
                    {
                        PrintError();
                        continue;
                    }
                }
                else if (command == "up")
                {
                    if ((moleRow - 1) >= 0)
                    {
                        moleRow--;
                    }
                    else
                    {
                        PrintError();
                        continue;
                    }
                }
                else if (command == "down")
                {
                    if ((moleRow + 1) < size)
                    {
                        moleRow++;
                    }
                    else
                    {
                        PrintError();
                        continue;
                    }
                }

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
                else if (matrix[moleRow, moleCol] != "M" && matrix[moleRow, moleCol] != "-")
                {
                    int currentPoints = int.Parse(matrix[moleRow, moleCol]);
                    points += currentPoints;

                    matrix[moleRow, moleCol] = "-";
                }
            }

            if (points >= 25)
            {
                Console.WriteLine($"Yay! The Mole survived another game!");
                Console.WriteLine($"The Mole managed to survive with a total of {points} points.");
            }
            else
            {
                Console.WriteLine("Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {points} points.");
            }

            matrix[moleRow, moleCol] = "M";

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}