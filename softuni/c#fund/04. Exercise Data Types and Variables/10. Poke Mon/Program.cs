using System;

namespace _10._Poke_Mon
{
    class Program
    {
        static void Main(string[] args)
        {
            int power = int.Parse(Console.ReadLine());
            int startingPower = power;
            int distance = int.Parse(Console.ReadLine());
            int exhaustFactor = int.Parse(Console.ReadLine());

            int counter = 0;

            while (power >= distance)
            {
                power -= distance;
                counter++;
                if (startingPower * 0.5 == power && exhaustFactor > 0)
                {
                        power /= exhaustFactor;
                }
            }
            Console.WriteLine(power);
            Console.WriteLine(counter);
        }
    }
}
