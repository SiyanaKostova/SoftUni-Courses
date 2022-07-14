using System;
using System.Linq;

namespace _02._Repeat_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split().ToArray();
            string result = string.Empty;

            foreach (string word in words)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    result += word;
                }
            }
            Console.WriteLine(result);
        }
    }
}
