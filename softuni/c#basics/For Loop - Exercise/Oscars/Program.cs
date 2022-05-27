using System;

namespace Oscars
{
    class Program
    {
        static void Main(string[] args)
        {
            const double NeededPointsForNominee = 1250.5;
            string name = Console.ReadLine();
            double academyPoints = double.Parse(Console.ReadLine());
            int countOfExamers = int.Parse(Console.ReadLine());

            double sumPoint = academyPoints;
            bool isActorFound = false;
            for (int iterator = 0; iterator < countOfExamers; iterator++)
            {
                string nameofJuri = Console.ReadLine();
                double pointsFromJuri = double.Parse(Console.ReadLine());

                double momentPoints = (nameofJuri.Length * pointsFromJuri / 2);
                sumPoint += momentPoints;
                if (sumPoint>=NeededPointsForNominee)
                {
                    isActorFound = true;
                    break;
                }
            }
            if (isActorFound)
            {
                Console.WriteLine($"Congratulations, {name} got a nominee for leading role with {sumPoint:f1}!");
            }
            else
            {
                double neededPoints = NeededPointsForNominee - sumPoint;
                Console.WriteLine($"Sorry, {name} you need {neededPoints:f1} more!");
            }
        }
    }
}
