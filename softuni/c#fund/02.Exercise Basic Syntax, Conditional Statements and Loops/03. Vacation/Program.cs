using System;

namespace _03._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());
            string groupType = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();
            double totalPrice = 0;

            if (groupType == "Students")
            {
                if (dayOfWeek == "Friday")
                {
                    totalPrice = peopleCount * 8.45;
                }
                else if (dayOfWeek == "Saturday")
                {
                    totalPrice = peopleCount * 9.80;
                }
                else if (dayOfWeek == "Sunday")
                {
                    totalPrice = peopleCount * 10.46;
                }
                if (peopleCount >= 30)
                {
                    totalPrice *= 0.85;
                }
            }
            else if (groupType == "Business")
            {
                if (dayOfWeek == "Friday")
                {
                    if (peopleCount>=100)
                    {
                        totalPrice = (peopleCount - 10) * 10.90;
                    }
                    else
                    {
                        totalPrice = peopleCount * 10.90;
                    }
                }
                else if (dayOfWeek == "Saturday")
                {
                    if (peopleCount >= 100)
                    {
                        totalPrice = (peopleCount - 10) * 15.60;
                    }
                    else
                    {
                        totalPrice = peopleCount * 15.60;
                    }
                }
                else if (dayOfWeek == "Sunday")
                {
                    if (peopleCount >= 100)
                    {
                        totalPrice = (peopleCount - 10) * 16;
                    }
                    else
                    {
                        totalPrice = peopleCount * 16;
                    }
                }
            }
            else if (groupType == "Regular")
            {
                if (dayOfWeek == "Friday")
                {
                    totalPrice = peopleCount * 15;
                }
                else if (dayOfWeek == "Saturday")
                {
                    totalPrice = peopleCount * 20;
                }
                else if (dayOfWeek == "Sunday")
                {
                    totalPrice = peopleCount * 22.50;
                }
                if (peopleCount >= 10&&peopleCount<=20)
                {
                    totalPrice *= 0.95;
                }
            }
            Console.WriteLine($"Total price: {totalPrice:f2}");
        }
    }
}
