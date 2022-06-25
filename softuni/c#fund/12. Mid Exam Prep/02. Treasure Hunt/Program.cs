using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Treasure_Hunt
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> loot = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> stolenThings = new List<string>();
            double totalSum = 0;
            string command = Console.ReadLine();

            while (command != "Yohoho!")
            {
                string[] tokens = command.Split();
                string action = tokens[0];

                switch (action)
                {
                    case "Loot":
                        for (int i = 1; i < tokens.Length; i++)
                        {
                            if (!loot.Contains(tokens[i]))
                            {
                                loot.Insert(0, tokens[i]);
                            }
                        }
                        break;

                    case "Drop":

                        int index = int.Parse(tokens[1]);
                        if (index >= 0 && index < loot.Count)
                        {
                            string temp = loot[index];
                            loot.RemoveAt(index);
                            loot.Add(temp);
                        }
                        break;

                    case "Steal":
                        int count = int.Parse(tokens[1]);
                        if (count < loot.Count)
                        {
                            for (int i = loot.Count - count; i < loot.Count; i++)
                            {
                                stolenThings.Add(loot[i]);
                            }
                            Console.WriteLine(string.Join(", ", stolenThings));
                            stolenThings.Clear();
                            loot.RemoveRange(loot.Count - count, count);
                        }
                        else
                        {
                            for (int i = 0; i < loot.Count; i++)
                            {
                                stolenThings.Add(loot[i]);
                            }
                            Console.WriteLine(string.Join(", ", stolenThings));
                            stolenThings.Clear();
                            loot.RemoveRange(0, loot.Count);
                        }


                        break;
                }


                command = Console.ReadLine();
            }

            if (loot.Count != 0)
            {
                double sum = 0;
                int counter = 0;
                for (int i = 0; i < loot.Count; i++)
                {
                    sum += loot[i].Length;
                    counter++;
                }
                totalSum = sum / counter;
                Console.WriteLine($"Average treasure gain: {totalSum:f2} pirate credits.");
            }
            else
            {
                Console.WriteLine("Failed treasure hunt.");
            }
        }
    }
}
