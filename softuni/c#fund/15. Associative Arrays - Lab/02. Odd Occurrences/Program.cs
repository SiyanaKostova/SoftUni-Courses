using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Odd_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> countOfWords = new Dictionary<string, int>();

            string[] words = Console.ReadLine().Split().Select(word => word.ToLower()).ToArray();

            foreach (var word in words)
            {
                if (!countOfWords.ContainsKey(word))
                {
                    countOfWords.Add(word, 0);
                }
                countOfWords[word]++;
            }

            string[] oddOcc = countOfWords.Where(w => w.Value % 2 != 0).Select(w => w.Key).ToArray();

            Console.WriteLine(string.Join(" ", oddOcc));
        }
    }
}
