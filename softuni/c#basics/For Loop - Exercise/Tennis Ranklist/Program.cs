using System;

namespace Tennis_Ranklist
{
    class Program
    {
        static void Main(string[] args)
        {
            const int finalistPoints = 1200;
            const int winnerPoints = 2000;
            const int SemiFinalistPoints = 720;
            int numberOfTournaments = int.Parse(Console.ReadLine());
            int startingPoints = int.Parse(Console.ReadLine());
            string currentStage = string.Empty;
            int points = 0;
            double average = 0;
            double percents = 0;
            int numberOfWonTournaments = 0;
            points = startingPoints;

            for (int iterator = 0; iterator < numberOfTournaments; iterator++)
            {
                currentStage = Console.ReadLine();
                if (currentStage=="F")
                {
                    points += finalistPoints;
                }
                else if (currentStage=="W")
                {
                    points += winnerPoints;
                    numberOfWonTournaments++;
                }
                else if (currentStage == "SF")
                {
                    points += SemiFinalistPoints;
                }
            }
            average = (points - startingPoints) / numberOfTournaments;
            percents = ((double) numberOfWonTournaments / numberOfTournaments) * 100;
            Console.WriteLine($"Final points: {points}");
            Console.WriteLine($"Average points: {Math.Floor(average)}");
            Console.WriteLine($"{percents:f2}%");
        }
    }
}
