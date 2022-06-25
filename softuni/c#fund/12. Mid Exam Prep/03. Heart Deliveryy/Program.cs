using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Heart_Deliveryy
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] neighbourhood = Console.ReadLine().Split('@').Select(int.Parse).ToArray();
            int locationOfCupid = 0;
            string command = Console.ReadLine();

            while (command!="Love!")
            {
                string[] tokens = command.Split();

                int length = int.Parse(tokens[1]);

                if (locationOfCupid + length > neighbourhood.Length - 1)
                {
                    locationOfCupid = 0;
                    CheckPlace(locationOfCupid, neighbourhood);
                }
                else
                {
                    locationOfCupid += length;
                    CheckPlace(locationOfCupid, neighbourhood);
                }
                command = Console.ReadLine();
            }

            Console.WriteLine($"Cupid's last position was {locationOfCupid}.");

            int failedPlaces = GetFailedPlaces(neighbourhood);

            if (failedPlaces > 0)
            {
                Console.WriteLine($"Cupid has failed {failedPlaces} places.");
            }
            else if (failedPlaces == 0)
            {
                Console.WriteLine("Mission was successful.");
            }

        }

        static void CheckPlace(int currentPosition, int[] places)
        {
            if (places[currentPosition] == 0)
            {
                Console.WriteLine($"Place {currentPosition} already had Valentine's day.");
            }
            else
            {
                places[currentPosition] -= 2;

                if (places[currentPosition] == 0)
                {
                    Console.WriteLine($"Place {currentPosition} has Valentine's day.");
                }
            }
        }

        static int GetFailedPlaces(int[] places)
        {
            int failedPlaces = 0;

            foreach (var heart in places)
            {
                if (heart != 0)
                {
                    failedPlaces++;
                }

            }

            return failedPlaces;
        }
    }
}
