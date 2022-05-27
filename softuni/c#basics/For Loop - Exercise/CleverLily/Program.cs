using System;

namespace CleverLily
{
    class Program
    {
        static void Main(string[] args)
        {
            int ageOfLili = int.Parse(Console.ReadLine());
            double priceOfLaundryM = double.Parse(Console.ReadLine());
            int priceOfSigleToy = int.Parse(Console.ReadLine());

            int toys = 0;
            int money = 0;
            int totalMoney = 0;
            for (int i = 1; i <= ageOfLili; i++)
            {
                money += 5;
                if (i%2==0)
                {
                    totalMoney += money - 1;
                }
                else
                {
                    toys++;
                }
            }
            totalMoney += toys * priceOfSigleToy;
            if (totalMoney>=priceOfLaundryM)
            {
                Console.WriteLine($"Yes! {totalMoney-priceOfLaundryM:f2}");
            }
            else
            {
                Console.WriteLine($"No! {priceOfLaundryM-totalMoney:f2}");
            }
        }
    }
}
