using System;

namespace zadacha_01
{
    class Program
    {
        static void Main(string[] args)
        {
            int numPeople = int.Parse(Console.ReadLine());
            int numNights = int.Parse(Console.ReadLine());
            int numCards = int.Parse(Console.ReadLine());
            int numCTicketsMuseum = int.Parse(Console.ReadLine());

            double priceNights = numNights * 20;
            double priceCards = numCards * 1.60;
            double priceMuseum = numCTicketsMuseum * 6;
            double sumForOnePerson = priceCards + priceNights + priceMuseum;
            double sumAll = numPeople * sumForOnePerson;

            double all = sumAll * 1.25;

            Console.WriteLine($"{all:f2}");
        }
    }
}
