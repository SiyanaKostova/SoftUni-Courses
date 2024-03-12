using System;
using System.Linq;
using System.Collections.Generic;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfClothes = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> clothesByColor = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < numberOfClothes; i++)
            {
                string[] tokens = Console.ReadLine().Split(new string[] {" -> ", ","}, StringSplitOptions.RemoveEmptyEntries);
                string color = tokens[0];

                if (!clothesByColor.ContainsKey(color))
                {
                    clothesByColor.Add(color, new Dictionary<string, int>());
                }
                for (int j = 1; j < tokens.Length; j++)
                {
                    string currentCloth = tokens[j];

                    if (!clothesByColor[color].ContainsKey(currentCloth))
                    {
                        clothesByColor[color].Add(currentCloth, 0);
                    }
                    clothesByColor[color][currentCloth]++;
                }
            }

            string[] searched = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var clothByColor in clothesByColor)
            {
                Console.WriteLine($"{clothByColor.Key} clothes:");
                foreach (var cloth in clothByColor.Value)
                {
                    string printItem = $"* {cloth.Key} - {cloth.Value}";
                    if (clothByColor.Key == searched[0] && cloth.Key == searched[1])
                    {
                        printItem += " (found!)";
                    }
                    Console.WriteLine(printItem);
                }
            }
        }
    }
}