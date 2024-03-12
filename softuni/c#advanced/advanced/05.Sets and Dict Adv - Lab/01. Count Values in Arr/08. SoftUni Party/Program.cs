using System;
using System.Linq;
using System.Collections.Generic;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> regulars = new HashSet<string>();
            HashSet<string> vips = new HashSet<string>();

            string incomingGuests = Console.ReadLine();

            while (incomingGuests != "PARTY")
            {
                char firstChar = incomingGuests[0];

                if (char.IsDigit(firstChar)) 
                {
                    vips.Add(incomingGuests);
                }
                else
                {
                    regulars.Add(incomingGuests);
                }
                incomingGuests = Console.ReadLine();
            }

            string guests = Console.ReadLine();

            while (guests != "END")
            {
                char firstChar = guests[0];

                if (char.IsDigit(firstChar))
                {
                    vips.Remove(guests);
                }
                else
                {
                    regulars.Remove(guests);
                }
                guests = Console.ReadLine();
            }

            int numberOfGuests = vips.Count + regulars.Count;
            Console.WriteLine(numberOfGuests);

            foreach (var vip in vips)
            {
                Console.WriteLine(vip);
            }
            foreach (var regular in regulars)
            {
                Console.WriteLine(regular);
            }
        }
    }
}
