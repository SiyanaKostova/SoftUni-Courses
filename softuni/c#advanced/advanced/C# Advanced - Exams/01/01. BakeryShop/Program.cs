using System;
using System.Linq;
using System.Collections.Generic;

namespace MyApp 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> firstInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToList();
            Queue<double> water = new Queue<double>(firstInput);

            List<double> secondInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToList();
            Stack<double> flour = new Stack<double>(secondInput);

            Dictionary<string, double> menu = new Dictionary<string, double>
            {
                {"Croissant", 50 },
                {"Muffin", 40 },
                {"Baguette", 30 },
                {"Bagel", 20 },
            };

            Dictionary<string, int> productsMade = new Dictionary<string, int>();

            while (water.Any() && flour.Any())
            {
                bool isFound = false;

                double currentWater = water.Peek();
                double currentFlour = flour.Peek();

                double sum = currentWater + currentFlour;
                double percantageOfWater = (currentWater * 100) / sum;

                foreach (var product in menu)
                {
                    if (product.Value == percantageOfWater)
                    {
                        isFound = true;

                        string pastry = product.Key;

                        if (!productsMade.ContainsKey(pastry))
                        {
                            productsMade.Add(pastry, 0);
                        }
                        productsMade[pastry]++;

                        water.Dequeue();
                        flour.Pop();

                        if (!isFound)
                        {
                            break;
                        }
                    }
                }
                if (!isFound)
                {
                    double percantageOfFlour = currentFlour * 100 / sum;
                    percantageOfWater = percantageOfFlour;

                    if (currentFlour > currentWater)
                    {
                        currentFlour -= currentWater;
                        water.Dequeue();
                        flour.Pop();
                        flour.Push(currentFlour);
                    }

                    if (!productsMade.ContainsKey("Croissant"))
                    {
                        productsMade.Add("Croissant", 0);
                    }
                    productsMade["Croissant"]++;
                }
            }

            var sortedProducts = productsMade.OrderByDescending(p => p.Value).ThenBy(p => p.Key).ToDictionary(p => p.Key, p => p.Value);

            foreach (var item in sortedProducts)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            if (water.Any())
            {
                Console.WriteLine($"Water left: {string.Join(", ", water)}");
            }
            else
            {
                Console.WriteLine("Water left: None");
            }

            if (flour.Any())
            {
                Console.WriteLine($"Flour left: {string.Join(", ", flour)}");
            }
            else
            {
                Console.WriteLine("Flour left: None");
            }
        }
    }
}