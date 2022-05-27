using System;

namespace SumSeconds
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstTime = int.Parse(Console.ReadLine());
            int secondTime = int.Parse(Console.ReadLine());
            int thirdTime = int.Parse(Console.ReadLine());
            int totalTIme = firstTime + secondTime + thirdTime;
            int minutes = totalTIme / 60;
            int seconds = totalTIme % 60;
            if (seconds<10)
            {
                Console.WriteLine($"{minutes}:0{seconds}");
            }
            else
            {
                Console.WriteLine($"{minutes}:{seconds}");
            }
        }
    }
}
