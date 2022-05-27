using System;

namespace _04._Reverse_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            for (int value = input.Length-1; value >= 0; value--)
            {
                Console.Write(input[value]);
            }
        }
    }
}
