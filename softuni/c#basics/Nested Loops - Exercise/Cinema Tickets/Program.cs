using System;

namespace Cinema_Tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int totalStudents = 0;
            int totalStandarts = 0;
            int totalKids = 0;
            int totalTickets = 0;
            while (command != "Finish")
            {
                int students = 0;
                int standart = 0;
                int kid = 0;
                int freeSpots = int.Parse(Console.ReadLine());
                for (int i = 0; i < freeSpots; i++)
                {
                    string ticketType = Console.ReadLine();
                    if (ticketType == "End")
                    {
                        break;
                    }
                    switch (ticketType)
                    {
                        case "student":
                            students++;
                            break;
                        case "standard":
                            standart++;
                            break;
                        case "kid":
                            kid++;
                            break;
                    }
                }
                totalStudents += students;
                totalStandarts += standart;
                totalKids += kid;
                double perecentageFull = (students + standart + kid) / (double)freeSpots * 100;
                Console.WriteLine($"{command} - {perecentageFull:f2}% full.");
                command = Console.ReadLine();
            }
            totalTickets = totalStudents + totalStandarts + totalKids;
            Console.WriteLine($"Total tickets: {totalTickets}");
            double standartPercentage = totalStandarts / (double)totalTickets * 100;
            double studentPercentage = totalStudents / (double)totalTickets * 100;
            double kidsPercentage = totalKids / (double)totalTickets * 100;
            Console.WriteLine($"{studentPercentage:f2}% student tickets.");
            Console.WriteLine($"{standartPercentage:f2}% standard tickets.");
            Console.WriteLine($"{kidsPercentage:f2}% kids tickets.");
        }
    }
}
