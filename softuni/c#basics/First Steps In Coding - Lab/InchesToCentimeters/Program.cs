using System;

namespace InchesToCentimeters
{
    class Program
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            double centimeters = num * 2.54;
            Console.WriteLine(centimeters);
        }
    }
}
