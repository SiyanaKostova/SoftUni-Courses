using System;

namespace Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersForIterations = int.Parse(Console.ReadLine());
            int p1 = 0;
            int p2 = 0;
            int p3 = 0;
            int p4 = 0;
            int p5 = 0;
            for (int iterator = 0; iterator < numbersForIterations; iterator++)
            {
                int currNum = int.Parse(Console.ReadLine());
                if (currNum<200)
                {
                    p1++;
                }
                else if (currNum<400)
                {
                    p2++;
                }
                else if (currNum<600)
                {
                    p3++;
                }
                else if (currNum<800)
                {
                    p4++;
                }
                else 
                {
                    p5++;
                }
            }
            double percentConvertP1 = 1.0 * p1 / numbersForIterations * 100;
            double percentConvertP2 = 1.0 * p2 / numbersForIterations * 100;
            double percentConvertP3 = 1.0 * p3 / numbersForIterations * 100;
            double percentConvertP4 = 1.0 * p4 / numbersForIterations * 100;
            double percentConvertP5 = 1.0 * p5 / numbersForIterations * 100;

            Console.WriteLine($"{percentConvertP1:f2}%");
            Console.WriteLine($"{percentConvertP2:f2}%");
            Console.WriteLine($"{percentConvertP3:f2}%");
            Console.WriteLine($"{percentConvertP4:f2}%");
            Console.WriteLine($"{percentConvertP5:f2}%");
        }
    }
}
