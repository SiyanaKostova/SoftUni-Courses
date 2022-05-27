using System;

namespace zadacha_02
{
    class Program
    {
        static void Main(string[] args)
        {
            double shirtPrice = double.Parse(Console.ReadLine());
            double neededPrice= double.Parse(Console.ReadLine());

            double priceShorti = shirtPrice * 0.75;
            double priceChorapi = priceShorti * 0.20;
            double priceButonki = (shirtPrice + priceShorti) * 2;
            double all = shirtPrice + priceShorti + priceChorapi + priceButonki;

            double afterSale = all * 0.85;

            if (afterSale>=neededPrice)
            {
                Console.WriteLine($"Yes, he will earn the world-cup replica ball!");
                Console.WriteLine($"His sum is {afterSale:f2} lv.");
            }
            else
            {
                double moreMoney = neededPrice - afterSale;
                Console.WriteLine($"No, he will not earn the world-cup replica ball.");
                Console.WriteLine($"He needs {moreMoney:f2} lv. more.");
            }
        }
    }
}
