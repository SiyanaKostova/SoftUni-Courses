using System;

namespace _08._Letters_Change_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double sum = 0;

            foreach (var item in input)
            {
                char firstLetter = item[0];
                char lastLetter = item[item.Length - 1];

                double number = double.Parse(item.Substring(1, item.Length - 2));

                double result = 0;

                if (firstLetter >= 65 && firstLetter <= 90)
                {
                    int firstLetterpositionInAlphabet = firstLetter - 64;
                    result = number / firstLetterpositionInAlphabet;
                }
                else
                {
                    int firstLetterpositionInAlphabet = firstLetter - 96;
                    result = number * firstLetterpositionInAlphabet;
                }

                if (lastLetter >= 65 && lastLetter <= 90)
                {
                    int lastLetterpositionInAlphabet = lastLetter - 64;
                    sum += result - lastLetterpositionInAlphabet;
                }
                else
                {
                    int lastLetterpositionInAlphabet = lastLetter - 96;
                    sum += result + lastLetterpositionInAlphabet;
                }
            }

            Console.WriteLine($"{sum:f2}");
        }
    }
}
