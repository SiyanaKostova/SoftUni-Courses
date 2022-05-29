using System;

namespace _03._Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());
            int elevatorCapacity = int.Parse(Console.ReadLine());

            double withReminderCourses = (double)peopleCount / elevatorCapacity;
            Console.WriteLine(Math.Ceiling(withReminderCourses));
        }
    }
}
