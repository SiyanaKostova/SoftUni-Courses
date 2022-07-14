using System;

namespace _04._Text_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine().Split(", ");
            string text = Console.ReadLine();

            foreach (var bannedWord in bannedWords)
            {
                text = text.Replace(bannedWord, new string('*', bannedWord.Length));
            }
            Console.WriteLine(text);
        }
    }
}
