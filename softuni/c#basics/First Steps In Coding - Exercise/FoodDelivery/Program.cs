using System;

namespace FoodDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int broiChicken = int.Parse(Console.ReadLine());
            int broiFish = int.Parse(Console.ReadLine());
            int broiVegan = int.Parse(Console.ReadLine());
            double priceCHicken = broiChicken * 10.35;
            double priceFish = broiFish * 12.40;
            double priceVegan = broiVegan * 8.15;
            double priceDessert = 0.2 * (priceCHicken + priceFish + priceVegan);
            double priceAll = priceCHicken + priceFish + priceVegan + priceDessert + 2.50;
            Console.WriteLine(priceAll);
        }
    }
}
