using System;

namespace FishingBoat
{
    class Program
    {
        static void Main(string[] args)
        {
            int budjet = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int numFisherman = int.Parse(Console.ReadLine());

            const double springRent = 3000.00;
            const double sumAutRent = 4200.00;
            const double winterRent = 2600.00;
            double price = 0.00;

            if (season == "Spring")
            {
                price += springRent;
            }
            else if (season=="Summer"||season=="Autumn")
            {
                price += sumAutRent;
            }
            else if (season=="Winter")
            {
                price += winterRent;
            }

            if (numFisherman<=6)
            {
                price *= 0.90;
            }
            else if (numFisherman>6&&numFisherman<12)
            {
                price *= 0.85;
            }
            else if (numFisherman>11)
            {
                price *= 0.75;
            }

            if (numFisherman%2==0&&season!="Autumn")
            {
                price *= 0.95;
            }

            double left = Math.Abs(price - budjet);

            if (price<=budjet)
            {
                Console.WriteLine($"Yes! You have {left:f2} leva left.");
            }
            else if (price>budjet)
            {
                Console.WriteLine($"Not enough money! You need {left:f2} leva.");
            }
            
        }
    }
}
