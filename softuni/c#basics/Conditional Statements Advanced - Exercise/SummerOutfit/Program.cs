using System;

namespace SummerOutfit
{
    class Program
    {
        static void Main(string[] args)
        {
            double degrees = double.Parse(Console.ReadLine());
            string timeOfDay = Console.ReadLine();
            string outfit = "";
            string shoes = "";
            if (degrees>=10&&degrees<=18)
            {
                if (timeOfDay=="Morning")
                {
                    outfit = "Sweatshirt";
                    shoes = "Sneakers";
                }
                else if (timeOfDay=="Afternoon")
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }
                else if (timeOfDay == "Evening")
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }
            }
            else if (degrees>18&&degrees<=24)
            {
                if (timeOfDay == "Morning")
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }
                else if (timeOfDay == "Afternoon")
                {
                    outfit = "T-Shirt";
                    shoes = "Sandals";
                }
                else if (timeOfDay == "Evening")
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }
            }
            else if (degrees>=25)
            {
                if (timeOfDay == "Morning")
                {
                    outfit = "T-Shirt";
                    shoes = "Sandals";
                }
                else if (timeOfDay == "Afternoon")
                {
                    outfit = "Swim Suit";
                    shoes = "Barefoot";
                }
                else if (timeOfDay == "Evening")
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }
            }
            Console.WriteLine($"It's {degrees} degrees, get your {outfit} and {shoes}.");
        }
    }
}
