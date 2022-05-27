using System;

namespace NewHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeFlower = Console.ReadLine();
            int numFlowers = int.Parse(Console.ReadLine());
            int budjet = int.Parse(Console.ReadLine());
            const double rosesPrice = 5.00;
            const double dahliaPrice = 3.80;
            const double tulipPrice = 2.80;
            const double narcissPrice = 3.00;
            const double gladiolPrice = 2.50;
            double totalPrice = 0.00;
            if (typeFlower=="Roses")
            {
                if (numFlowers > 80)
                {
                    totalPrice -= rosesPrice * numFlowers * 0.10;
                }
                    totalPrice += rosesPrice * numFlowers;
            }

            else if (typeFlower == "Dahlias")
            {
                
                if (numFlowers > 90)
                {
                    totalPrice -= dahliaPrice * numFlowers * 0.15;
                }
                    totalPrice += dahliaPrice * numFlowers;
            }

            else if (typeFlower == "Tulips")
            {
                if (numFlowers > 80)
                {
                    totalPrice -= tulipPrice * numFlowers * 0.15;
                }
                    totalPrice += tulipPrice * numFlowers;
            }

            else if (typeFlower == "Narcissus")
            {
                if (numFlowers < 120)
                {
                    totalPrice += narcissPrice * numFlowers * 0.15;
                }
                    totalPrice += narcissPrice * numFlowers;
            }

            else if (typeFlower == "Gladiolus")
            {
                if (numFlowers < 80)
                {
                    totalPrice += gladiolPrice * numFlowers * 0.20;
                }
                    totalPrice += gladiolPrice * numFlowers;
            }

            double left = Math.Abs(budjet - totalPrice);
            if (totalPrice<=budjet)
            {
                Console.WriteLine($"Hey, you have a great garden with {numFlowers} {typeFlower} and {left:f2} leva left.");
            }
            else if (totalPrice>budjet)
            {
                Console.WriteLine($"Not enough money, you need {left:f2} leva more.");
            }
        }
    }
}
