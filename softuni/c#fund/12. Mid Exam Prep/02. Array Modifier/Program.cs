using System;
using System.Linq;
using System.Collections.Generic;

namespace _02._Array_Modifier
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            string command = Console.ReadLine();

            while (command!="end")
            {
                string[] tokens = command.Split();
                string action = tokens[0];

                switch (action)
                {
                    case "swap":
                        Swap(int.Parse(tokens[1]), int.Parse(tokens[2]), numbers);
                        break;
                    case "multiply":
                        Multiply(int.Parse(tokens[1]), int.Parse(tokens[2]), numbers);
                        break;
                    case "decrease":
                        Decrease(numbers);
                        break;
                }

                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(", ", numbers));
        }

        private static void Decrease(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                numbers[i]--;
            }
        }

        private static void Multiply(int firstIndex, int secondIndex, List<int> numbers)
        {
            numbers[firstIndex] = numbers[firstIndex] * numbers[secondIndex];
        }

        private static void Swap(int firstIndex, int secondIndex, List<int> numbers)
        {
            int temp = numbers[firstIndex];

            numbers[firstIndex] = numbers[secondIndex];
            numbers[secondIndex] = temp;
        }
    }
}
