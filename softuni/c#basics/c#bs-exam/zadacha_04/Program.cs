using System;

namespace zadacha_04
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            double M = double.Parse(Console.ReadLine());
            double Km = M;
            double allKm = M;
            for (int i = 1; i <= N; i++)
            {
                double percentage = double.Parse(Console.ReadLine());
                Km = Km + Km * (percentage / 100);
                allKm = allKm + Km;
            }
            
            if (allKm >= 1000)
            {
                double more = allKm - 1000;
                Console.WriteLine($"You've done a great job running {Math.Ceiling(more)} more kilometers!");
            }
            else
            {
                double needed = 1000 - allKm;
                Console.WriteLine($"Sorry Mrs. Ivanova, you need to run {Math.Ceiling(needed)} more kilometers");
            }
        }
    }
}
