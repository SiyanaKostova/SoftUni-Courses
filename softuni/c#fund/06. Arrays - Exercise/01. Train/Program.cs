using System;

namespace _01._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfWagons = int.Parse(Console.ReadLine());
            int[] wagons = new int[numOfWagons];
            int sum = 0;

            for (int indexOfWagons = 0; indexOfWagons < numOfWagons; indexOfWagons++)
            {
                wagons[indexOfWagons] = int.Parse(Console.ReadLine());
                sum += wagons[indexOfWagons];

            }
            for (int i = 0; i < wagons.Length; i++)
            {
                Console.Write($"{wagons[i]} ");
            }
            Console.WriteLine();
            Console.WriteLine(sum);
        }
    }
}
