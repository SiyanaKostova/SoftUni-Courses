using System;
using System.Text;

namespace _06._Replace_Repeating_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            sb.Append(text[0]);

            for (int i = 1; i < text.Length; i++)
            {
                if (text[i] != text[i - 1])
                {
                    sb.Append(text[i]);
                }
            }

            Console.WriteLine(sb);
        }
    }
}
