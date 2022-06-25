using System;

namespace _01._Counter_Strike
{
    class Program
    {
        static void Main(string[] args)
        {
            int initialEnergy = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            int wonGames = 0;

            while (command != "End of battle")
            {
                int distance = int.Parse(command);

                if (distance <= initialEnergy)
                {
                    initialEnergy -= distance;
                    wonGames++;
                }
                else
                {
                    Console.WriteLine($"Not enough energy! Game ends with {wonGames} won battles and {initialEnergy} energy");
                    return;
                }
                if (wonGames % 3 == 0)
                {
                    initialEnergy += wonGames;
                }

                command = Console.ReadLine();
            }
            Console.WriteLine($"Won battles: {wonGames}. Energy left: {initialEnergy}");
        }
    }
}
