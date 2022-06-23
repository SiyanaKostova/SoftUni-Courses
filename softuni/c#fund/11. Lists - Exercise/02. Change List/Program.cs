using System;
using System.Linq;
using System.Collections.Generic;

namespace _02._Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string line = Console.ReadLine();

            while (line!="end")
            {
                string[] tokens = line.Split();
                string command = tokens[0];
                if (command=="Delete")
                {
                    int element = int.Parse(tokens[1]);
                    numbers.RemoveAll(el => el == element);
                }
                else if (command=="Insert")
                {
                    int element = int.Parse(tokens[1]);
                    int index = int.Parse(tokens[2]);
                    numbers.Insert(index, element);
                }
                line = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
