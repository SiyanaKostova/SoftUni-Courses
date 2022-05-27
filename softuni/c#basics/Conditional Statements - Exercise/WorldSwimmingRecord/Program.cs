using System;

namespace WorldSwimmingRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            double recSec = double.Parse(Console.ReadLine());
            double distanceMeters = double.Parse(Console.ReadLine());
            double timeOneMeterSec = double.Parse(Console.ReadLine());
            double secSwimmingMustSwim = distanceMeters * timeOneMeterSec;
            double numStopping = Math.Floor(distanceMeters / 15);
            double secStopping = numStopping * 12.5;
            double totalTime = secSwimmingMustSwim + secStopping;

            if (totalTime < recSec)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {totalTime:f2} seconds.");
            }
            else if (totalTime > recSec)
            {
                double loss = Math.Abs(recSec - totalTime);
                Console.WriteLine($"No, he failed! He was {loss:f2} seconds slower.");
            } */


            double recordSeconds = double.Parse(Console.ReadLine());
            double metersToSwim = double.Parse(Console.ReadLine());
            double secondsPerMeter = double.Parse(Console.ReadLine());
            double slowTime = Math.Floor(metersToSwim / 15) * 12.5;
            double totalTime = metersToSwim * secondsPerMeter + slowTime;
            if (totalTime < recordSeconds)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {totalTime:f2} seconds.");
            }
            else if (totalTime >= recordSeconds)
            {
                double timeSlower = totalTime - recordSeconds;
                Console.WriteLine($"No, he failed! He was {timeSlower:f2} seconds slower.");
            }
        }
    }
}
