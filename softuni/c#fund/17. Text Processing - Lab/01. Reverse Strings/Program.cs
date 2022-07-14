using System;

namespace _01._Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string result = string.Empty;

            while (input != "end")
            {
                for (int i = input.Length - 1; i >= 0; i--)
                {
                    char currentLetter = input[i];
                    result += currentLetter;
                }

                Console.WriteLine($"{input} = {result}");
                result = string.Empty;

                input = Console.ReadLine();
            }
        }
    }
}
