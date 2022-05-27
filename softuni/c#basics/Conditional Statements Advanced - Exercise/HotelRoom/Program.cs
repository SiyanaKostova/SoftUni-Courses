using System;

namespace HotelRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            const double mayOctStudioPrice = 50;
            const double mayOctApartmentPrice = 65;
            const double juneSeptStudioPrice = 75.20;
            const double juneSeptApartmentPrice = 68.70;
            const double julyAugStudioPrice = 76;
            const double julyAugApartmentPrice = 77;

            string season = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());
            double totalMoneyForStudio = 0;
            double totalMoneyForApartment = 0;

            switch (season)
            {
                case "May":
                case "October":
                    totalMoneyForStudio = nights * mayOctStudioPrice;
                    totalMoneyForApartment = nights * mayOctApartmentPrice;
                    if (nights>7&&nights<14)
                    {
                        totalMoneyForStudio -= totalMoneyForStudio * 0.05;
                    }
                    else if (nights>14)
                    {
                        totalMoneyForStudio -= totalMoneyForStudio * 0.3;
                    }
                    break;
                case "June":
                case "September":
                    totalMoneyForStudio = nights * juneSeptStudioPrice;
                    totalMoneyForApartment = nights * juneSeptApartmentPrice;
                    if (nights>14)
                    {
                        totalMoneyForStudio -= totalMoneyForStudio * 0.20;
                    }
                    break;
                case "July":
                case "August":
                    totalMoneyForStudio = julyAugStudioPrice * nights;
                    totalMoneyForApartment = julyAugApartmentPrice * nights;
                    break;
            }
            if (nights>14)
            {
                totalMoneyForApartment -= totalMoneyForApartment * 0.10;
            }
            Console.WriteLine($"Apartment: {totalMoneyForApartment:f2} lv.");
            Console.WriteLine($"Studio: {totalMoneyForStudio:f2} lv.");
        }
    }
}
