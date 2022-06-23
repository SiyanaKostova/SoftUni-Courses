using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._House_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> listOfNames = new List<string>();

            for (int i = 0; i < n; i++)
            {
                var command = Console.ReadLine().Split();
                string currentName = command[0];

                if (listOfNames.Contains(currentName) && command[2] == "going!")
                {
                    Console.WriteLine($"{currentName} is already in the list!");
                }
                else if (listOfNames.Contains(currentName) && command[2] == "not")
                {
                    listOfNames.Remove(currentName);                }
                else if (!listOfNames.Contains(currentName)&& command[2] == "not")
                {
                    Console.WriteLine($"{currentName} is not in the list!");
                }
                else
                {
                    listOfNames.Add(currentName);
                }
            }
            foreach (var currentName in listOfNames)
            {
                Console.WriteLine(currentName);
            }
        }
    }
}
