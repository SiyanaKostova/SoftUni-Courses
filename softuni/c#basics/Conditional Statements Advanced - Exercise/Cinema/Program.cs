using System;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfProject = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int colums = int.Parse(Console.ReadLine());
            
            const double premierePrice = 12.00;
            const double normalPrice = 7.50;
            const double discountPrice = 5.00;
            double income = 0.0;

            if (typeOfProject=="Premiere")
            {
                income = rows * colums * premierePrice;
            }
            else if (typeOfProject=="Normal")
            {
                income = rows * colums * normalPrice;
            }
            else if (typeOfProject == "Discount")
            {
                income = rows * colums * discountPrice;
            }
            Console.WriteLine($"{income:f2} leva");
        }
    }
}
