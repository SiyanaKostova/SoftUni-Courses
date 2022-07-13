using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Snowwhite
{
    class Program
    {
        static void Main(string[] args)
        {
            var dwarfs = new Dictionary<string, int>();
            string command = Console.ReadLine();

            while (command != "Once upon a time")
            {
                string[] tokens = command.Split(" <:> ", StringSplitOptions.RemoveEmptyEntries);

                string dwarfName = tokens[0];
                string hatColor = tokens[1];
                int physcs = int.Parse(tokens[2]);

                var dwarfID = $"{dwarfName}:{hatColor}";

                if (!dwarfs.ContainsKey(dwarfID))
                {
                    dwarfs.Add(dwarfID, physcs);
                }
                else
                {
                    dwarfs[dwarfID] = Math.Max(dwarfs[dwarfID], physcs);
                }

                command = Console.ReadLine();
            }

            foreach (var dwarf in dwarfs.OrderByDescending(x => x.Value)
                .ThenByDescending(y => dwarfs
                .Where(hatcolor => hatcolor.Key.Split(":")[1] == y.Key.Split(":")[1]).Count()))
            {
                Console.WriteLine($"({dwarf.Key.Split(":")[1]}) {dwarf.Key.Split(":")[0]} <-> {dwarf.Value}");
            }
        }
    }
}
