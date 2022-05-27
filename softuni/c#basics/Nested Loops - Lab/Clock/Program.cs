using System;

namespace Clock
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int hour = 0; hour <= 23; hour++)
            {
                for (int min = 0; min <= 59; min++)
                {
                        Console.WriteLine($"{hour:d2}:{min:d2}");
                }
            }
        }
    }
}
