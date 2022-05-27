using System;

namespace VowelsSum
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int sum = 0;
            for (int i = 0; i < text.Length; i++)
            {
                char currentSymbol = text[i];
                if (currentSymbol=='a')
                {
                    sum += 1;
                }
               if (currentSymbol == 'e')
               {
                    sum += 2;
               }
               if (currentSymbol == 'i')
                {
                    sum += 3;
                }
               if (currentSymbol == 'o')
                {
                    sum += 4;
                }
               if (currentSymbol == 'u')
                {
                    sum += 5;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
