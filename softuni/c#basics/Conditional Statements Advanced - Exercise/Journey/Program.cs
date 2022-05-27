using System;

namespace Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budjet = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string place = "";
            string type = "";
            double price = 0.00;

            if (budjet<=100)
            {
                place = "Bulgaria";
                if (season=="summer")
                {
                    price = 0.3 * budjet;
                }
                else if (season=="winter")
                {
                    price = 0.7 * budjet;
                }
            }
            else if (budjet <= 1000)
            {
                place = "Balkans";
                if (season == "summer")
                {
                    price = 0.4 * budjet;
                }
                else if (season == "winter")
                {
                    price = 0.8 * budjet;
                }
            }
            else if (budjet > 1000)
            {
                place="Europe";
                type = "Hotel";
                price = 0.9 * budjet;
            }

            if (season=="summer"&&place!="Europe")
            {
                type = "Camp";
            }
            else if (season=="winter")
            {
                type = "Hotel";
            }

            Console.WriteLine($"Somewhere in {place}");
            Console.WriteLine($"{type} - {price:f2}");
          
        }
    }
}
