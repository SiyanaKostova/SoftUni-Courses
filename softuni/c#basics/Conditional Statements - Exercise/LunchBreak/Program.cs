using System;

namespace LunchBreak
{
    class Program
    {
        static void Main(string[] args)
        {
            string tvSeries = Console.ReadLine();
            int episodeTime = int.Parse(Console.ReadLine());
            double brakeTime = int.Parse(Console.ReadLine());
            double lunchTimeBrake = brakeTime / 8;
            double relaxationTime = brakeTime / 4;
            double timeLeft = brakeTime - (lunchTimeBrake + relaxationTime);
            double neededTime = Math.Abs(episodeTime - timeLeft);
            Console.WriteLine(timeLeft >= episodeTime ? $"You have enough time to watch {tvSeries} and left with {Math.Ceiling(neededTime)} minutes free time." : $"You don't have enough time to watch {tvSeries}, you need {Math.Ceiling(neededTime)} more minutes.");
        }
    }
}
