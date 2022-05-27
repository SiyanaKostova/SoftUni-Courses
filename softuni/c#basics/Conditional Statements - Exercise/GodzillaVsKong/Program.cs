using System;

namespace GodzillaVsKong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budjet = double.Parse(Console.ReadLine());
            int statistiNum = int.Parse(Console.ReadLine());
            double oblekloEdinStatist = double.Parse(Console.ReadLine());
            double dekor = 0.1 * budjet;
            double priceObleklo = statistiNum * oblekloEdinStatist;
            if (statistiNum>150)
            {
                priceObleklo *= 0.90;
            }
            if (dekor+priceObleklo>budjet)
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {((dekor+priceObleklo)-budjet):f2} leva more.");
            }
            else if (dekor+priceObleklo<=budjet)
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {budjet-(dekor+priceObleklo):f2} leva left.");
            }
        }
    }
}
