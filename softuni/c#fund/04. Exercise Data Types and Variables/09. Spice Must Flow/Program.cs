using System;

namespace _09._Spice_Must_Flow
{
    class Program
    {
        static void Main(string[] args)
        {
            const int CONSUMED_BY_WORKERS = 26;
            const int MINIMUM_SPICES_TO_GATHER_FROM_MINE = 100;
            const int DAILY_DECREASE_OF_MINE_FIELD = 10;

            int countOfSpices = int.Parse(Console.ReadLine());
            int totalConsumed = 0;
            int daysCounter = 0;

            while (countOfSpices>=MINIMUM_SPICES_TO_GATHER_FROM_MINE)
            {
                totalConsumed += countOfSpices - CONSUMED_BY_WORKERS;
                countOfSpices -= DAILY_DECREASE_OF_MINE_FIELD;
                daysCounter++;

                if (countOfSpices<MINIMUM_SPICES_TO_GATHER_FROM_MINE)
                {
                    totalConsumed -= CONSUMED_BY_WORKERS;
                }
            }
            Console.WriteLine(daysCounter);
            Console.WriteLine(totalConsumed);
        }
    }
}
