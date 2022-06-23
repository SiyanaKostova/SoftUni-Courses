using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._List_Manipulation_Advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            bool isListChanged = false;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }
                string[] tokens = command.Split();
                string action = tokens[0];

                switch (action)
                {
                    case "Add":
                        int numberToAdd = int.Parse(tokens[1]);
                        numbers.Add(numberToAdd);
                        isListChanged = true;
                        break;
                    case "Remove":
                        int numberToRemove = int.Parse(tokens[1]);
                        numbers.Remove(numberToRemove);
                        isListChanged = true;
                        break;
                    case "RemoveAt":
                        int indexToRemoveAt = int.Parse(tokens[1]);
                        numbers.RemoveAt(indexToRemoveAt);
                        isListChanged = true;
                        break;
                    case "Insert":
                        int numberToInsert = int.Parse(tokens[1]);
                        int indexToInsert = int.Parse(tokens[2]);
                        numbers.Insert(indexToInsert, numberToInsert);
                        isListChanged = true;
                        break;
                    case "Contains":
                        CheckContains(int.Parse(tokens[1]), numbers);
                        break;
                    case "PrintEven":
                        PrintEven(numbers);
                        break;
                    case "PrintOdd":
                        PrintOdd(numbers);
                        break;
                    case "GetSum":
                        int sum = GetSum(numbers);
                        Console.WriteLine(sum);
                        break;
                    case "Filter":
                        PrintFiltered(tokens[1], int.Parse(tokens[2]), numbers);
                        break;
                    default:
                        break;
                }
            }
            if (isListChanged)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
        }

        static int GetSum(List<int> numbers)
        {
            int sum = 0;
            foreach (int number in numbers)
            {
                sum += number;
            }
            return sum;
        }

        static void PrintEven(List<int> numbers)
        {
            foreach (var number in numbers)
            {
                if (number % 2 == 0)
                {
                    Console.Write($"{number} ");
                }
            }
            Console.WriteLine();
        }
        static void PrintOdd(List<int> numbers)
        {
            foreach (var number in numbers)
            {
                if (number % 2 != 0)
                {
                    Console.Write($"{number} ");
                }
            }
            Console.WriteLine();
        }

        static void CheckContains(int numberToCheck, List<int> numbers)
        {
            if (numbers.Contains(numberToCheck))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No such number");
            }
        }

        static void PrintFiltered(string filter, int numberToFilter, List<int> numbers)
        {
            switch (filter)
            {
                case "<":
                    foreach (var number in numbers)
                    {
                        if (number < numberToFilter)
                        {
                            Console.Write($"{number} ");
                        }
                    }
                    Console.WriteLine();
                    break;
                case "<=":
                    foreach (var number in numbers)
                    {
                        if (number <= numberToFilter)
                        {
                            Console.Write($"{number} ");
                        }
                    }
                    Console.WriteLine();
                    break;
                case ">":
                    foreach (var number in numbers)
                    {
                        if (number > numberToFilter)
                        {
                            Console.Write($"{number} ");
                        }
                    }
                    Console.WriteLine();
                    break;
                case ">=":
                    foreach (var number in numbers)
                    {
                        if (number >= numberToFilter)
                        {
                            Console.Write($"{number} ");
                        }
                    }
                    Console.WriteLine();
                    break;
            }
        }
    }
}
