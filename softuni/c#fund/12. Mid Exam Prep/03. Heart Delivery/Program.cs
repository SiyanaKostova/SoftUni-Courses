using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Moving_Target
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine().Split().Select(int.Parse).ToList();

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] tokens = command.Split();
                string action = tokens[0];

                switch (action)
                {
                    case "Shoot":
                        int indexShoot = int.Parse(tokens[1]);
                        int powerShoot = int.Parse(tokens[2]);
                        Shoot(indexShoot, powerShoot, targets);
                        break;

                    case "Add":
                        int indexAdd = int.Parse(tokens[1]);
                        int valueAdd = int.Parse(tokens[2]);
                        Add(indexAdd, valueAdd, targets);
                        break;

                    case "Strike":
                        int indexStrike = int.Parse(tokens[1]);
                        int radiusStrike = int.Parse(tokens[2]);
                        Strike(indexStrike, radiusStrike, targets);
                        break;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join("|", targets));
        }

        static void Strike(int indexStrike, int radiusStrike, List<int> targets)
        {
            if (indexStrike < 0 || indexStrike > targets.Count-1 
                || indexStrike - radiusStrike < 0
                || indexStrike + radiusStrike > targets.Count-1)
            {
                Console.WriteLine("Strike missed!");
                return;
            }
            targets.RemoveRange(indexStrike - radiusStrike, radiusStrike * 2 + 1);
        }

        static void Add(int indexAdd, int valueAdd, List<int> targets)
        {
            if (indexAdd >=0 && indexAdd<=targets.Count-1)
            {
                targets.Insert(indexAdd, valueAdd);
            }
            else
            {
                Console.WriteLine("Invalid placement!");
                return;
            }
        }

        static void Shoot(int indexShoot, int powerShoot, List<int> targets)
        {
            if (indexShoot >= 0 && indexShoot <= targets.Count - 1)
            {
                targets[indexShoot] -= powerShoot;
            }
            else
            {
                return;
            }
            if (targets[indexShoot] <= 0)
            {
                targets.RemoveAt(indexShoot);
            }
        }
    }
}
