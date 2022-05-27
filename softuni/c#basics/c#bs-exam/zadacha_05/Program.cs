using System;

namespace zadacha_05
{
    class Program
    {
        static void Main(string[] args)
        {
            string Break = Console.ReadLine();
            int Meters = int.Parse(Console.ReadLine());
            int counterDays = 1;
            int metersFromStart = 5364;
            int peak = 8848;

            while (Break != "END")
            {

                if (Break == "Yes")
                {
                    counterDays++;
                    metersFromStart += Meters;
                }
                else if (Break == "No")
                {
                    metersFromStart += Meters;
                }
                if (counterDays > 5 && metersFromStart < peak)
                {
                    Console.WriteLine($"Failed!");
                    Console.WriteLine($"{metersFromStart - Meters}");
                    break;
                }
                else if (counterDays > 5 && metersFromStart >= peak)
                {
                    Console.WriteLine($"Goal reached for {counterDays} days!");
                }
                if (peak <= metersFromStart)
                {
                    Console.WriteLine($"Goal reached for {counterDays} days!");
                    break;
                }


                Break = Console.ReadLine();
                if (Break == "END")
                {
                    Console.WriteLine($"Failed!");
                    Console.WriteLine($"{metersFromStart}");
                    break;
                }

                Meters = int.Parse(Console.ReadLine());
            }
        }
    }
}
