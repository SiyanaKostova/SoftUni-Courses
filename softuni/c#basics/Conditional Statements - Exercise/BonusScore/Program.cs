using System;

namespace BonusScore
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            double bonus = 0.0;
            if (number<=100)
            {
                bonus = 5;
            }
            else if (number>1000)
            {
                bonus = 0.1 * number;
            }
            else 
            {
                bonus = 0.2 * number;
            }
            if (number%2==0)
            {
                bonus = bonus + 1;
            }
            else if (number%10==5)
            {
                bonus += 2;
            }
            Console.WriteLine(bonus);
            Console.WriteLine(number+bonus);
        }
    }
}
