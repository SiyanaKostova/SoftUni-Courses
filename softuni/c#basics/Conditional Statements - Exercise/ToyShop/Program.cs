using System;

namespace ToyShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceTrip = double.Parse(Console.ReadLine());
            int numPuzel = int.Parse(Console.ReadLine());
            int numDolls = int.Parse(Console.ReadLine());
            int numBears = int.Parse(Console.ReadLine());
            int numMinions = int.Parse(Console.ReadLine());
            int numTrucks = int.Parse(Console.ReadLine());

            const double pricePuzel = 2.60;
            const double priceDolls = 3;
            const double priceBears = 4.10;
            const double priceMinion = 8.20;
            const double priceTrucks = 2;

            int numToys = numPuzel + numDolls + numBears + numMinions + numTrucks;
            double totalPrice = numPuzel * pricePuzel + numDolls * priceDolls + numBears * priceBears + numMinions * priceMinion + numTrucks * priceTrucks;
            if (numToys>=50)
            {
                totalPrice *= 0.75;
            }
            double rent = totalPrice * 0.10;
            double difference = Math.Abs(rent + priceTrip - totalPrice);
            if (totalPrice>=rent+priceTrip)
            {
                Console.WriteLine($"Yes! {difference:f2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {difference:f2} lv needed.");
            }
        }
    }
}
