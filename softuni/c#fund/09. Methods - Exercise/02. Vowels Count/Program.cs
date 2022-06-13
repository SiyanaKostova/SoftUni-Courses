using System;
using System.Linq;

namespace _02._Vowels_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToLower();
            SearchForVowels(input);
        }
        static void SearchForVowels(string text)
        {
            Console.WriteLine(text.Count(vowels => "aoeui".Contains(vowels)));
        }
    }
}
