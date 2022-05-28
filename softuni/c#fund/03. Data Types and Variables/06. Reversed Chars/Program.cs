using System;

namespace _06._Reversed_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());
            char third = char.Parse(Console.ReadLine());
            Console.WriteLine($"{third} {second} {first}");
        }
    }
}
