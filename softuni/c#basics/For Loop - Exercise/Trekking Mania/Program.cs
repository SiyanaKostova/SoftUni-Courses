using System;

namespace Trekking_Mania
{
    class Program
    {
        static void Main(string[] args)
        {
            int groupsOfPeople = int.Parse(Console.ReadLine());
            int groupe1 = 0;
            int groupe2 = 0;
            int groupe3 = 0;
            int groupe4 = 0;
            int groupe5 = 0;

            for (int i = 1; i <= groupsOfPeople ; i++)
            {
                int climbersCount = int.Parse(Console.ReadLine());
                if (climbersCount<6)
                {
                    groupe1 += climbersCount;
                }
                else if (climbersCount < 13)
                {
                    groupe2 += climbersCount;
                }
                else if (climbersCount < 26)
                {
                    groupe3 += climbersCount;
                }
                else if (climbersCount < 41)
                {
                    groupe4 += climbersCount;
                }
                else
                {
                    groupe5 += climbersCount;
                }
            }
            int totalclimberscount = groupe1 + groupe2 + groupe3 + groupe4 + groupe5;
            double convertGroup1 = 1.0 * groupe1 / totalclimberscount * 100;
            double convertGroup2 = 1.0 * groupe2 / totalclimberscount * 100;
            double convertGroup3 = 1.0 * groupe3 / totalclimberscount * 100;
            double convertGroup4 = 1.0 * groupe4 / totalclimberscount * 100;
            double convertGroup5 = 1.0 * groupe5 / totalclimberscount * 100;
            Console.WriteLine($"{convertGroup1:f2}%");
            Console.WriteLine($"{convertGroup2:f2}%");
            Console.WriteLine($"{convertGroup3:f2}%");
            Console.WriteLine($"{convertGroup4:f2}%");
            Console.WriteLine($"{convertGroup5:f2}%");
        }
    }
}
