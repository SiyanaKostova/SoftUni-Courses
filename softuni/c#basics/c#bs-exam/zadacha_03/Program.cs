using System;

namespace zadacha_03
{
    class Program
    {
        static void Main(string[] args)
        {
            double weight = double.Parse(Console.ReadLine());
            string typeOfOrder = Console.ReadLine();
            double distance = double.Parse(Console.ReadLine());
            double money = 0;
            double standardMoney = 0;
            double over = 0;
            double obshta = 0;
            double overKg = 0;

            switch (typeOfOrder)
            {
                case "standard":
                    if (weight<1)
                    {
                        money = 0.03 * distance;
                    }
                    else if (weight>=1&&weight<10)
                    {
                        money = 0.05 * distance;
                    }
                    else if (weight >= 10 && weight < 40)
                    {
                        money = 0.10 * distance;
                    }
                    else if (weight >= 40 && weight < 90)
                    {
                        money = 0.15 * distance;
                    }
                    else if (weight >= 90 && weight < 150)
                    {
                        money = 0.20 * distance;
                    }
                    break;
                case "express":
                    if (weight < 1)
                    {
                        standardMoney = 0.03 * distance;
                        overKg = 0.80 * 0.03;
                        over = weight * overKg;
                        obshta = distance * over;
                        money = standardMoney + obshta;
                    }
                    else if (weight >= 1 && weight < 10)
                    {
                        standardMoney = 0.05 * distance;
                        overKg = 0.40 * 0.05;
                        over = weight * overKg;
                        obshta = distance * over;
                        money = standardMoney + obshta;
                    }
                    else if (weight >= 10 && weight < 40)
                    {
                        standardMoney = 0.10 * distance;
                        overKg = 0.05 * 0.10;
                        over = weight * overKg;
                        obshta = distance * over;
                        money = standardMoney + obshta;
                    }
                    else if (weight >= 40 && weight < 90)
                    {
                        standardMoney = 0.15 * distance;
                        overKg = 0.02 * 0.15;
                        over = weight * overKg;
                        obshta = distance * over;
                        money = standardMoney + obshta;
                    }
                    else if (weight >= 90 && weight < 150)
                    {
                        standardMoney = 0.20 * distance;
                        overKg = 0.01 * 0.20;
                        over = weight * overKg;
                        obshta = distance * over;
                        money = standardMoney + obshta;
                    }
                    break;
            }
            Console.WriteLine($"The delivery of your shipment with weight of {weight:f3} kg. would cost {money:f2} lv.");
        }
    }
}
