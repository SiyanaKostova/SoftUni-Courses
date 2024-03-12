using System;
using System.Linq;
using System.Collections.Generic;

namespace MyApp 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> foodCalories = new Dictionary<string, int>();
            foodCalories.Add("salad", 350);
            foodCalories.Add("soup", 490);
            foodCalories.Add("pasta", 680);
            foodCalories.Add("steak", 790);


            List<string> listMeals = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            Queue<string> meals = new Queue<string>();
            foreach (var k in listMeals)
            {
                meals.Enqueue(k);
            }

            Stack<int> daily = new Stack<int>();
            List<int> dailyIntake = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            foreach (var d in dailyIntake)
            {
                daily.Push(d);
            }

            int remainingCalories = 0;
            bool daySet = false;
            bool isOK = true;

            foreach (var meal in listMeals)
            {
                int intake = foodCalories[meal];

                if (daySet == false)
                {
                    remainingCalories = daily.Peek();
                    daySet = true;
                }
                remainingCalories -= intake;
                meals.Dequeue();

                if (remainingCalories <= 0)
                {
                    int num = Math.Abs(remainingCalories);
                    daily.Pop();
                    if (daily.Count >= 1)
                    {
                        remainingCalories = daily.Peek();
                        remainingCalories -= num;
                    }
                    else
                    {
                        Console.WriteLine($"John ate enough, he had {listMeals.Count - meals.Count} meals.");
                        Console.WriteLine($"Meals left: {string.Join(", ", meals)}.");
                        isOK = false;
                        break;
                    }
                }

                daily.Pop();
                daily.Push(remainingCalories);
            }

            if (isOK == true)
            {
                Console.WriteLine($"John had {listMeals.Count} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", daily)} calories.");
            }
        }
    }
}