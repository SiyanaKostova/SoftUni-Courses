using System;

namespace _09._Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int countOfStudents = int.Parse(Console.ReadLine());
            double priceOfSaber = double.Parse(Console.ReadLine());
            double priceOfRobes = double.Parse(Console.ReadLine());
            double priceOfBelts = double.Parse(Console.ReadLine());

            double totalNumberOfSabers = Math.Ceiling(countOfStudents * 1.10);
            double totalNumberOfFreeBelts = Math.Floor(countOfStudents / 6.0);

            double finalPriceForSabers = totalNumberOfSabers * priceOfSaber;
            double finalPriceForRobes = countOfStudents * priceOfRobes;
            double finalPriceForBelts = (countOfStudents - totalNumberOfFreeBelts) * priceOfBelts;
            double totalFinal = finalPriceForSabers + finalPriceForRobes + finalPriceForBelts;

            if (budget>=totalFinal)
            {
                Console.WriteLine($"The money is enough - it would cost {totalFinal:f2}lv.");
            }
            else
            {
                Console.WriteLine($" John will need {(totalFinal-budget):f2}lv more.");
            }

        }
    }
}
