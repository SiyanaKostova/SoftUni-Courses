using System;

namespace Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            const double videoCardPrice = 250;

            double budjet = double.Parse(Console.ReadLine());
            int videoCardNum = int.Parse(Console.ReadLine());
            int ProcesorNum = int.Parse(Console.ReadLine());
            int RamPametNum = int.Parse(Console.ReadLine());
            double totalVideoCardPrice = videoCardNum * videoCardPrice;
            double totalProcesorPrice = totalVideoCardPrice * 0.35;
            double totalRamPametPrice = totalVideoCardPrice * 0.10;
            double totalMoney = totalVideoCardPrice + totalProcesorPrice * ProcesorNum
                + totalRamPametPrice * RamPametNum;
            if (videoCardNum>ProcesorNum)
            {
                totalMoney *= 0.85;
            }
            double difference = Math.Abs(totalMoney - budjet)
;           Console.WriteLine(budjet >= totalMoney
    ? $"You have {difference:f2} leva left!"
    : $"Not enough money! You need {difference:f2} leva more!");
        }
    }
}
