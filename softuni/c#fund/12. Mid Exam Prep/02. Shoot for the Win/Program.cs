using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Shoot_for_the_Win
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> targets = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            string command = Console.ReadLine();
            int temp;
            int counter = 0;

            while (command != "End")
            {
                int index = int.Parse(command);

                if (index >= 0 && index <= targets.Count - 1)
                {
                    if (targets[index] != -1)
                    {
                        temp = targets[index];

                        targets.RemoveAt(index);
                        targets.Insert(index, -1);
                        counter++;

                        for (int i = 0; i < targets.Count; i++)
                        {
                            if (targets[i] != -1)
                            {
                                if (targets[i] > temp)
                                {
                                    targets[i] -= temp;
                                }
                                else if (targets[i] <= temp)
                                {
                                    targets[i] += temp;
                                }
                            }
                        }
                    }
                }
                command = Console.ReadLine();
            }

            Console.WriteLine($"Shot targets: {counter} -> {string.Join(" ", targets)}");
        }
    }
}
