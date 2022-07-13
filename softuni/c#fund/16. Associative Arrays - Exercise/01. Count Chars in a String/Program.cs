using System;
using System.Collections.Generic;

namespace _01._Count_Chars_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> letters = new Dictionary<char, int>();

            char[] word = Console.ReadLine().ToCharArray();

            foreach (var letter in word)
            {
                if (letter != ' ')
                {
                    if (!letters.ContainsKey(letter))
                    {
                        letters[letter] = 0;
                    }
                    letters[letter]++;
                }
            }
            foreach (var kvpLetter in letters)
            {
                Console.WriteLine($"{kvpLetter.Key} -> {kvpLetter.Value}");
            }
        }
    }
}
