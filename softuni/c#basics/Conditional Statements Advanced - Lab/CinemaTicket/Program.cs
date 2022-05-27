using System;

namespace CinemaTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            string day = Console.ReadLine();
            int priceOfTicket = 0;
            switch (day)
            {
                case "Monday":
                case "Tuesday":
                case "Friday":
                    priceOfTicket = 12;
                    break;
                case "Wednesday":
                case "Thursday":
                    priceOfTicket = 14;
                    break;
                case "Saturday":
                case "Sunday":
                    priceOfTicket = 16;
                    break;
            }
            Console.WriteLine(priceOfTicket);
        }
    }
}
