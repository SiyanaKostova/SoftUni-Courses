using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace MyApp 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            string[,] matrix = new string[size, size];

            int armoryRow = 0;
            int armoryCol = 0;

            bool isFirstMirrorFound = false;

            int firstMirrorRow = 0;
            int firstMirrorCol = 0;
            int secondMirrorRow = 0;
            int secondMirrorCol = 0;

            for (int row = 0; row < size; row++)
            {
                string data = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = (data[col]).ToString();

                    if (matrix[row, col] == "A")
                    {
                        armoryRow = row;
                        armoryCol = col;
                        matrix[row, col] = "-";
                    }

                    if (matrix[row, col] == "M")
                    {
                        if (!isFirstMirrorFound)
                        {
                            firstMirrorRow = row;
                            firstMirrorCol = col;
                            isFirstMirrorFound = true;
                        }
                        else
                        {
                            secondMirrorRow = row;
                            secondMirrorCol = col;
                        }
                    }
                }
            }

            string command = string.Empty;
            int blades = 0;

            while (true)
            {
                int previousRow = armoryRow;
                int previousCol = armoryCol;

                if (blades >= 65)
                {
                    Console.WriteLine("Very nice swords, I will come back for more!");
                    Console.WriteLine($"The king paid {blades} gold coins.");
                    matrix[armoryRow, armoryCol] = "A";
                    break;
                }

                command = Console.ReadLine();

                switch (command)
                {
                    case "up":
                        armoryRow--;
                        break;
                    case "down":
                        armoryRow++;
                        break;
                    case "left":
                        armoryCol--;
                        break;
                    case "right":
                        armoryCol++;
                        break;
                }

                if (!IsInside(armoryRow, armoryCol, size))
                {
                    Console.WriteLine("I do not need more swords!");
                    Console.WriteLine($"The king paid {blades} gold coins.");
                    matrix[previousRow, previousCol] = "-";
                    break;
                }

                if (matrix[armoryRow, armoryCol] == "M")
                {
                        matrix[armoryRow, armoryCol] = "-";

                        if (firstMirrorRow == armoryRow && firstMirrorCol == armoryCol)
                        {
                            armoryRow = secondMirrorRow;
                            armoryCol = secondMirrorCol;
                        }
                        else
                        {
                            
                            armoryRow = firstMirrorRow;
                            armoryCol = firstMirrorCol;
                        }

                       matrix[armoryRow, armoryCol] = "-";
                }
                else if (matrix[armoryRow, armoryCol] != "-")
                {
                    int sword = int.Parse(matrix[armoryRow, armoryCol]);
                    blades += sword;
                    matrix[armoryRow, armoryCol] = "-";
                }
            }

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }

            static bool IsInside(int row, int col, int size)
            {
                return row >= 0 && row < size &&
                       col >= 0 && col < size;
            }
        }
    }
}