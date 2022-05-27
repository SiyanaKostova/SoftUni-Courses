using System;

namespace RectangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            int sideA = int.Parse(Console.ReadLine());
            int sideB = int.Parse(Console.ReadLine());
            int result = sideA * sideB;
            Console.WriteLine(result);
        }
    }
}
