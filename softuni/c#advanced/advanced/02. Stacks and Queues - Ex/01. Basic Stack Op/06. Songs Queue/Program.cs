using System;
using System.Linq;
using System.Collections.Generic;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> songs = new (Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries));

            while (songs.Any())
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];

                switch (command)
                {
                    case "Play":
                        songs.Dequeue();
                        break;

                    case "Add":
                        string songName = string.Join(" ", tokens.Skip(1));

                        if (songs.Contains(songName))
                        {
                            Console.WriteLine($"{songName} is already contained!");
                        }
                        else
                        {
                            songs.Enqueue(songName);
                        }
                        break;

                    case "Show":
                        Console.WriteLine(string.Join(", ", songs));
                        break;
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}