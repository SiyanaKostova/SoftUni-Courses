using System;

namespace SkiTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            const double priceRoomForOnePerson = 18;
            const double priceForApartment = 25;
            const double priceForPresidentApartment = 35;

            int countDays = int.Parse(Console.ReadLine());
            string roomType = Console.ReadLine();
            string rating = Console.ReadLine();
            int nights = countDays - 1;
            double totalPrice = 0;

            switch (roomType)
            {
                case "room for one person":
                    totalPrice = nights * priceRoomForOnePerson;
                    break;
                case "apartment":
                    totalPrice = nights * priceForApartment;
                    if (countDays>15)
                    {
                        totalPrice *= 0.5;
                    }
                    else if (countDays>=10)
                    {
                        totalPrice *= 0.65;
                    }
                    else
                    {
                        totalPrice *= 0.6;
                    }
                    break;
                case "president apartment":
                    totalPrice = nights * priceForPresidentApartment;
                    if (countDays>15)
                    {
                        totalPrice *= 0.8;
                    }
                    else if (countDays>=10)
                    {
                        totalPrice *= 0.85;
                    }
                    else
                    {
                        totalPrice *= 0.9;
                    }
                    break;
            }
            switch (rating)
            {
                case "positive":
                    totalPrice *= 1.25;
                    break;
                case "negative":
                    totalPrice *= 0.9;
                    break;
            }
            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
