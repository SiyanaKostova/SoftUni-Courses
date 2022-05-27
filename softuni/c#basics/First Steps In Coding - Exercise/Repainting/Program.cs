using System;

namespace Repainting
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantitiNailon = int.Parse(Console.ReadLine());
            int quantitiBoq = int.Parse(Console.ReadLine());
            int quantitiRazreditel = int.Parse(Console.ReadLine());
            int chasRabota = int.Parse(Console.ReadLine());

            double priceNailon = (quantitiNailon+2) * 1.50;
            double priceBoq = (quantitiBoq*1.1) * 14.50;
            double priceRazreditel = quantitiRazreditel * 5;
            double priceMaistor = chasRabota * (0.3 * (priceNailon + priceBoq + priceRazreditel + 0.40));
            double sum = priceNailon + priceBoq + priceRazreditel + 0.40 + priceMaistor;
            Console.WriteLine(sum);
        }
    }
}
