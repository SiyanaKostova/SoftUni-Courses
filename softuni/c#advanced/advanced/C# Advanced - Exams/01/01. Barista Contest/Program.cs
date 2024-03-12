using System;
using System.Linq;
using System.Collections.Generic;

namespace MyApp
{
    public class Program
    {
        private static void Main(string[] args)
        {
            List<int> firstInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            Queue<int> coffee = new Queue<int>(firstInput);

            List<int> secondInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            Stack<int> milk = new Stack<int>(secondInput);

            Dictionary<string, int> instructions = new Dictionary<string, int>
            {
                {"Cortado", 50 },
                {"Espresso", 75 },
                {"Capuccino", 100 },
                {"Americano", 150 },
                {"Latte", 200 },
            };

            Dictionary<string, int> beverages = new Dictionary<string, int>();

            while (milk.Any() && coffee.Any())
            {
                bool isDrinkMade = false;

                int currCoffee = coffee.Peek();
                int currMilk = milk.Peek();
                int sum = currCoffee + currMilk;

                foreach (var drink in instructions)
                {
                    string name = drink.Key;

                    if (drink.Value == sum)
                    {
                        isDrinkMade = true;
                        coffee.Dequeue();
                        milk.Pop();

                        if (!beverages.ContainsKey(name))
                        {
                            beverages.Add(name, 0);
                        }
                        beverages[name]++;
                        break;
                    }
                }

                if (!isDrinkMade)
                {
                    coffee.Dequeue();
                    int decreasedMilk = milk.Peek() - 5;
                    milk.Pop();
                    milk.Push(decreasedMilk);
                }
            }

            if ((!milk.Any()) && (!coffee.Any()))
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            }
            else
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            }

            if (coffee.Any())
            {
                Console.WriteLine($"Coffee left: {string.Join(", ", coffee)}");
            }
            else
            {
                Console.WriteLine("Coffee left: none");
            }

            if (milk.Any())
            {
                Console.WriteLine($"Milk left: {string.Join(", ", milk)}");
            }
            else
            {
                Console.WriteLine("Milk left: none");
            }

            var sortedBeverages = beverages.OrderBy(b => b.Value).ThenByDescending(b => b.Key);

            foreach (var beverage in sortedBeverages)
            {
                Console.WriteLine($"{beverage.Key}: {beverage.Value}");
            }
        }
    }
}