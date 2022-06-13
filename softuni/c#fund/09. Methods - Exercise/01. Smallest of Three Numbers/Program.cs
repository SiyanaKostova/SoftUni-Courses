using System;

namespace _01._Smallest_of_Three_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            PrintSmallestNumber(firstNumber, secondNumber, thirdNumber);
        }
        static void PrintSmallestNumber(int first, int second, int third) => Console.WriteLine(Math.Min(first, Math.Min(second, third)));
    }
}
