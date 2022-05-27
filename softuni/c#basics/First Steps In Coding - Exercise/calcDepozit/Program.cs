using System;

namespace calcDepozit
{
    class Program
    {
        static void Main(string[] args)
        {
            double depSum = double.Parse(Console.ReadLine());
            int srok = int.Parse(Console.ReadLine());
            double lihva = double.Parse(Console.ReadLine());
            double sum = depSum + srok * ((depSum * (lihva/100)) / 12);
            Console.WriteLine(sum);
        }
    }
}
