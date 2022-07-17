using System;

namespace _02._Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string first = input[0];
            string second = input[1];

            Console.WriteLine(CharMultiplier(first, second));
        }
        public static int CharMultiplier(string first, string second)
        {
            int sum = 0;

            string longest = "";
            string shortest = "";

            if (first.Length > second.Length)
            {
                longest = first;
                shortest = second;
            }
            else
            {
                longest = second;
                shortest = first;
            }

            for (int i = 0; i < shortest.Length; i++)
            {
                sum += first[i] * second[i];
            }

            for (int i = shortest.Length; i < longest.Length; i++)
            {
                sum += longest[i];
            }

            return sum;
        }
    }
}
