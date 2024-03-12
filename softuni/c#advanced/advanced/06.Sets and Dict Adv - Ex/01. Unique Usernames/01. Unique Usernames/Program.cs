using System;
using System.Linq;
using System.Collections.Generic;

namespace MyApp 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfUsernames = int.Parse(Console.ReadLine());
            List<string> usernames = new List<string>();

            for (int i = 0; i < numberOfUsernames; i++)
            {
                string name = Console.ReadLine();

                if (!usernames.Contains(name))
                {
                    usernames.Add(name);
                }
            }
            foreach (var username in usernames)
            {
                Console.WriteLine(username);
            }
        }
    }
}