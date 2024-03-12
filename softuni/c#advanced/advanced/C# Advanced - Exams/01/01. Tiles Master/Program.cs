using System;
using System.Linq;
using System.Collections.Generic;

namespace MyApp 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            Stack<int> whiteTiles = new Stack<int>(firstInput);

            List<int> secondInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            Queue<int> greyTiles = new Queue<int>(secondInput);

            Dictionary<string, int> tilesPlace = new Dictionary<string, int>
            {
                {"Sink", 40 },
                {"Oven", 50 },
                {"Countertop", 60 },
                {"Wall", 70 },
            };

            Dictionary<string, int> tilesCount = new Dictionary<string, int>();

            while (whiteTiles.Any() && greyTiles.Any())
            {

                if (whiteTiles.Peek() == greyTiles.Peek())
                {
                    int tilesValue = whiteTiles.Peek() + greyTiles.Peek();
                    bool isThere = false;
                    foreach (var place in tilesPlace)
                    {
                        if (place.Value == tilesValue)
                        {
                            isThere = true;

                            if (!tilesCount.ContainsKey(place.Key))
                            {
                                tilesCount.Add(place.Key, 1);
                            }
                            else
                            {
                                tilesCount[place.Key]++;
                            }
                        }

                    }
                    if (isThere == false)
                    {
                        if (!tilesCount.ContainsKey("Floor"))
                        {
                            tilesCount.Add("Floor", 0);
                        }
                        tilesCount["Floor"]++;
                    }

                    isThere = false;
                    whiteTiles.Pop();
                    greyTiles.Dequeue();
                }
                else
                {
                    int newWhiteTile = whiteTiles.Peek() / 2;
                    whiteTiles.Pop();
                    whiteTiles.Push(newWhiteTile);

                    int newGreyTile = greyTiles.Peek();
                    greyTiles.Dequeue();
                    greyTiles.Enqueue(newGreyTile);
                }
            }

            if (whiteTiles.Any())
            {
                Console.WriteLine($"White tiles left: {string.Join(", ", whiteTiles)}");
            }
            else
            {
                Console.WriteLine($"White tiles left: none");
            }
            if (greyTiles.Any())
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", greyTiles)}");
            }
            else
            {
                Console.WriteLine($"Grey tiles left: none");
            }

            var sortedTiles = tilesCount.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var place in sortedTiles)
            {
                Console.WriteLine($"{place.Key}: {place.Value}");
            }
        }
    }
}
