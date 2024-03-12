using System;
using System.Linq;
using System.Collections.Generic;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, int> participantsPoints = new SortedDictionary<string, int>();
            SortedDictionary<string, int> languagesSubmissions = new SortedDictionary<string, int>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "exam finished")
            {
                string[] tokens = command.Split("-", StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];

                if (tokens[1] == "banned")
                {
                    participantsPoints.Remove(name);
                    continue;
                }

                string language = tokens[1];
                int points = int.Parse(tokens[2]);

                if (!participantsPoints.ContainsKey(name))
                {
                    participantsPoints.Add(name, 0);
                }
                if (participantsPoints[name] < points)
                {
                    participantsPoints[name] = points;
                }

                if (!languagesSubmissions.ContainsKey(language))
                {
                    languagesSubmissions.Add(language, 0);
                }
                languagesSubmissions[language]++;

            }

            var orderedParticipants = participantsPoints.OrderByDescending(p => p.Value);

            Console.WriteLine("Results:");
            foreach (var points in orderedParticipants)
            {
                Console.WriteLine($"{points.Key} | {points.Value}");
            }

            var orderedLanguages = languagesSubmissions.OrderByDescending(l => l.Value);

            Console.WriteLine("Submissions:");
            foreach (var languages in orderedLanguages)
            {
                Console.WriteLine($"{languages.Key} - {languages.Value}");
            }
        }
    }
}