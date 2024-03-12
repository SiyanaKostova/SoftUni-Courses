using System;
using System.Linq;
using System.Collections.Generic;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, HashSet<string>>> vloggers = new();
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[1];

                if (command == "joined")
                {
                    string vloggerName = tokens[0];

                    if (!vloggers.ContainsKey(vloggerName))
                    {
                        vloggers.Add(vloggerName, new Dictionary<string, HashSet<string>>());
                        vloggers[vloggerName].Add("followers", new HashSet<string>());
                        vloggers[vloggerName].Add("following", new HashSet<string>());
                    }
                }
                else if (command == "followed")
                {
                    string vlogger = tokens[0];
                    string vloggerToFollow = tokens[2];

                    if (vloggers.ContainsKey(vlogger) &&
                        vloggers.ContainsKey(vloggerToFollow) &&
                        vlogger != vloggerToFollow)
                    {
                        vloggers[vlogger]["following"].Add(vloggerToFollow);
                        vloggers[vloggerToFollow]["followers"].Add(vlogger);
                    }
                }
            }

            int count = 1;

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            var orderedVloggers = vloggers
                .OrderByDescending(v => v.Value["followers"].Count)
                .ThenBy(v => v.Value["following"].Count);

            foreach (var vlogger in orderedVloggers)
            {
                Console.WriteLine($"{count}. {vlogger.Key} : {vlogger.Value["followers"].Count} followers, {vlogger.Value["following"].Count} following");

                if (count == 1)
                {
                    var orderedFollowers = vlogger.Value["followers"]
                        .OrderBy(f => f);

                    foreach (var follower in orderedFollowers)
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }

                count++;
            }
        }
    }
}