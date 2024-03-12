using System;
using System.Collections.Generic;


namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Array.Reverse(input);

            Stack<string> stack = new Stack<string>(input);
            int result = 0;
            int currentResult = int.Parse(stack.Pop());
            string operation;
            int secondNumber;
            
            while (stack.Count != 0)
            {
                operation = stack.Pop();
                secondNumber = int.Parse(stack.Pop());

                if (operation == "+")
                {
                    currentResult += secondNumber;
                }
                else if (operation == "-")
                {
                    currentResult -= secondNumber;
                }

                result += currentResult;
                currentResult = 0;
            }

            Console.WriteLine(result);
        }
    }
}