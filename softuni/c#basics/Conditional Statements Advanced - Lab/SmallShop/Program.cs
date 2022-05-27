using System;

namespace SmallShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string drink = Console.ReadLine();
            string town = Console.ReadLine();
            double num = double.Parse(Console.ReadLine());
            double price = 0;
            if (town=="Sofia")
            {
                switch (drink)
                {
                    case "coffee":
                        price = 0.50 * num;
                        break;
                    case "water":
                        price = 0.80 * num;
                        break;
                    case "beer":
                        price = 1.20 * num;
                        break;
                    case "sweets":
                        price = 1.45 * num;
                        break;
                    case "peanuts":
                        price = 1.60 * num;
                        break;
                }
            }
            else if (town=="Plovdiv")
            {
                switch (drink)
                {
                    case "coffee":
                        price = 0.40 * num;
                        break;
                    case "water":
                        price = 0.70 * num;
                        break;
                    case "beer":
                        price = 1.15 * num;
                        break;
                    case "sweets":
                        price = 1.30 * num;
                        break;
                    case "peanuts":
                        price = 1.50 * num;
                        break;
                }
            }
            else if (town == "Varna")
            {
                switch (drink)
                {
                    case "coffee":
                        price = 0.45 * num;
                        break;
                    case "water":
                        price = 0.70 * num;
                        break;
                    case "beer":
                        price = 1.10 * num;
                        break;
                    case "sweets":
                        price = 1.35 * num;
                        break;
                    case "peanuts":
                        price = 1.55 * num;
                        break;
                }
            }
            Console.WriteLine(price);
        }
    }
}
