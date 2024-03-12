using System;
using System.Linq;
using System.Collections.Generic;

namespace MyApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<int> firstInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            Queue<int> steel = new Queue<int>(firstInput);

            List<int> secondInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            Stack<int> carbon = new Stack<int>(secondInput);

            Dictionary<int, string> swords = new Dictionary<int, string>
            {
                { 70, "Gladius" },
                { 80, "Shamshir" },
                { 90, "Katana" },
                { 110, "Sabre" },
                { 150, "Broadsword" },

            };

            Dictionary<string, int> swordsMade = new Dictionary<string, int>();

            while (steel.Any() && carbon.Any())
            {
                int currSteel = steel.Peek();
                int currCarbon = carbon.Peek();

                int sum = currCarbon + currSteel;

                if (swords.ContainsKey(sum))
                {
                    steel.Dequeue();
                    carbon.Pop();

                    if (!swordsMade.ContainsKey(swords[sum]))
                    {
                        swordsMade.Add(swords[sum], 1);
                    }
                    else
                    {
                        swordsMade[swords[sum]]++;
                    }
                }
                else
                {
                    steel.Dequeue();
                    int currentCarbon = carbon.Pop() + 5;
                    carbon.Push(currentCarbon);
                }
            }


            int sumSwords = 0;
            foreach (var item in swordsMade)
            {
                sumSwords += item.Value;
            }
            if (sumSwords > 0)
            {
                Console.WriteLine($"You have forged {sumSwords} swords.");
            }
            else
            {
                Console.WriteLine($"You did not have enough resources to forge a sword.");
            }

            if (steel.Any())
            {
                Console.WriteLine($"Steel left: {string.Join(", ", steel)}");
            }
            else
            {
                Console.WriteLine($"Steel left: none");
            }
            if (carbon.Any())
            {
                Console.WriteLine($"Carbon left: {string.Join(", ", carbon)}");
            }
            else
            {
                Console.WriteLine($"Carbon left: none");
            }

            var sortedSwords = swordsMade.OrderBy(s => s.Key).ToDictionary(s => s.Key, s => s.Value);

            foreach (var item in sortedSwords)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}