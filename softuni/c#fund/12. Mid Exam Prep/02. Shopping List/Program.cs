using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Shopping_List
{
    class Program
    {
        static void Main(string[] args)
        {

            int waitingPeople = int.Parse(Console.ReadLine());
            int[] lift = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int maxPeoplePerWagon = 4;

            for (int i = 0; i < lift.Length; i++)
            {
                for (int j = lift[i]; j < maxPeoplePerWagon; j++)
                {
                    waitingPeople--;
                    lift[i]++;

                    if (waitingPeople == 0)
                    {
                        if (lift.Sum() < lift.Length * maxPeoplePerWagon)
                        {
                            Console.WriteLine("The lift has empty spots!");
                        }
                        Console.WriteLine(string.Join(" ", lift));
                        return;
                    }

                }
            }

            Console.WriteLine($"There isn't enough space! {waitingPeople} people in a queue!");
            Console.WriteLine(string.Join(" ", lift));

        }
    }
}
