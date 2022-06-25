using System;

namespace _01._Guinea_Pig
{
    class Program
    {
        static void Main(string[] args)
        {

            double food = double.Parse(Console.ReadLine()) * 1000;
            double hay = double.Parse(Console.ReadLine()) * 1000;
            double cover = double.Parse(Console.ReadLine()) * 1000;
            double weight = double.Parse(Console.ReadLine()) * 1000;

            bool isFoodEnough = true;

            for (int i = 1; i <= 30; i++)
            {
                food -= 300;
                if (i % 2 == 0)
                {
                    hay -= food * 0.05;
                }
                if (i % 3 == 0)
                {
                    cover -= weight / 3;
                }
                if (food <= 0 || hay <= 0 || cover <= 0)
                {
                    isFoodEnough = false;
                    Console.WriteLine("Merry must go to the pet store!");
                    return;
                }
            }

            if (isFoodEnough)
            {
                Console.WriteLine($"Everything is fine! Puppy is happy! Food: {(food / 1000):f2}, Hay: {(hay / 1000):f2}, Cover: {(cover / 1000):f2}.");
            }
        }
    }
}
