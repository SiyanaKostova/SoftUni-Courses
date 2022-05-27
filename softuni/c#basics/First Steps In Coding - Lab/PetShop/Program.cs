using System;

namespace PetShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int numDog = int.Parse(Console.ReadLine());
            int numCat = int.Parse(Console.ReadLine());
            double sum = numDog * 2.5 + numCat * 4;
            Console.WriteLine($"{sum} lv.");
        }
    }
}
