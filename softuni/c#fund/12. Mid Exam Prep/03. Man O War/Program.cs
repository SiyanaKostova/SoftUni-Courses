using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Man_O_War
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> pirateShip = Console.ReadLine().Split(">", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<int> warship = Console.ReadLine().Split(">", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            int maxCapacity = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();

            while (command != "Retire")
            {
                string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0];

                switch (action)
                {
                    case "Fire":
                        int indexFire = int.Parse(tokens[1]);
                        int damageFire = int.Parse(tokens[2]);
                        if (indexFire >= 0 && indexFire < warship.Count)
                        {
                            warship[indexFire] -= damageFire;
                            if (warship[indexFire] <= 0)
                            {
                                Console.WriteLine($"You won! The enemy ship has sunken.");
                                return;
                            }
                        }
                        break;

                    case "Defend":

                        int startIndexDefend = int.Parse(tokens[1]);
                        int endIndexDefend = int.Parse(tokens[2]);
                        int damageDefend = int.Parse(tokens[3]);

                        if (startIndexDefend >= 0 && startIndexDefend<=pirateShip.Count && endIndexDefend < pirateShip.Count && endIndexDefend>=0)
                        {
                            for (int i = startIndexDefend; i <= endIndexDefend; i++)
                            {
                                pirateShip[i] -= damageDefend;

                                if (pirateShip[i] <= 0)
                                {
                                    Console.WriteLine($"You lost! The pirate ship has sunken.");
                                    return;
                                }
                            }

                        }
                        break;

                    case "Repair":

                        int indexRepair = int.Parse(tokens[1]);
                        int healthRepair = int.Parse(tokens[2]);

                        if (indexRepair >= 0 && indexRepair < warship.Count)
                        {
                            pirateShip[indexRepair] += healthRepair;
                            if (pirateShip[indexRepair] >= maxCapacity)
                            {
                                pirateShip[indexRepair] = maxCapacity;
                            }
                        }
                        break;

                    case "Status":

                        int counter = 0;

                        for (int i = 0; i < pirateShip.Count; i++)
                        {
                            if (pirateShip[i] <= maxCapacity * 0.2)
                            {
                                counter++;
                            }
                        }
                        Console.WriteLine($"{counter} sections need repair.");
                        break;
                }

                command = Console.ReadLine();
            }
            int pirateShipSum = pirateShip.Sum();
            int warshipSum = warship.Sum();
            Console.WriteLine($"Pirate ship status: {pirateShipSum}");
            Console.WriteLine($"Warship status: {warshipSum}");
        }
    }
}
