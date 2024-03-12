using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.WebSockets;

namespace MyApp 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<char> firstInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToList();
            Queue<char> vowels = new Queue<char>(firstInput);

            List<char> secondInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToList();
            Stack<char> consonants = new Stack<char>(secondInput);

            string[] words = new string[]
            {
                "pear", "flour", "pork", "olive"
            };

            while (consonants.Any())
            {
                char currVowel = vowels.Peek();
                char currCons = consonants.Peek();

                foreach (var word in words)
                {
                    if (word.Contains(currVowel.ToString()))
                    {

                    }
                }
            }
        }
    }
}
