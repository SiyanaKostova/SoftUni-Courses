using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04._Star_Enigma
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"@(?<name>[A-z]+)[^@\-!:>]*:(?<population>[\d]+)[^@\-!:>]*!(?<type>[A,D])![^@\-!:>]*->(?<count>[\d]+)";
            int linesOfInput = int.Parse(Console.ReadLine());
            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();

            for (int i = 0; i < linesOfInput; i++)
            {
                string message = Console.ReadLine();
                int sum = message.ToLower().Count(x => x == 's' || x == 't' || x == 'a' || x == 'r');
                string decriptedMesage = "";
                foreach (var currSymbol in message)
                {
                    decriptedMesage += (char)(currSymbol - sum);
                }

                Match matches = Regex.Match(decriptedMesage, pattern, RegexOptions.IgnoreCase);
                if (matches.Success)
                {
                    string name = matches.Groups["name"].Value;
                    int population = int.Parse(matches.Groups["population"].Value);
                    char type = char.Parse(matches.Groups["type"].Value);
                    int soldiersCount = int.Parse(matches.Groups["count"].Value);

                    if (type != 'A')
                    {
                        destroyedPlanets.Add(name);
                    }
                    else
                    {
                        attackedPlanets.Add(name);
                    }
                }
            }
            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            attackedPlanets.OrderBy(x => x).ToList().ForEach(planet => Console.WriteLine($"-> {planet}"));
            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            destroyedPlanets.OrderBy(x => x).ToList().ForEach(planet => Console.WriteLine($"-> {planet}"));
        }
    }
}
