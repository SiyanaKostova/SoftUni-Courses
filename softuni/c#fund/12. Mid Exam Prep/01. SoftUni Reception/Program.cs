using System;

namespace _01._SoftUni_Reception
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstWorker = int.Parse(Console.ReadLine());
            int secondWorker = int.Parse(Console.ReadLine());
            int thirdWorker = int.Parse(Console.ReadLine());

            int answersPerHour = firstWorker + secondWorker + thirdWorker;

            int studentsCount = int.Parse(Console.ReadLine());

            int hours = 0;

            while (studentsCount > 0)
            {
                studentsCount -= answersPerHour;
                hours++;

                if (hours % 4 == 0)
                {
                    hours++;
                }
            }

            Console.WriteLine($"Time needed: {hours}h.");
        }
    }
}
