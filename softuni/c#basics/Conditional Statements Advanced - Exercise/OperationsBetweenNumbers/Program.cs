using System;

namespace OperationsBetweenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstNum = double.Parse(Console.ReadLine());
            double secondNum = double.Parse(Console.ReadLine());
            string symbol = Console.ReadLine();
            double result = 0.00;

            if (symbol == "+")
            {
                result = firstNum + secondNum;
                if (result % 2 == 0)
                {
                    Console.WriteLine($"{firstNum} + {secondNum} = {result} - even");
                }
                else
                {
                    Console.WriteLine($"{firstNum} + {secondNum} = {result} - odd");
                }
            }
            else if (symbol == "-")
            {
                result = firstNum - secondNum;
                if (result % 2 == 0)
                {
                    Console.WriteLine($"{firstNum} - {secondNum} = {result} - even");
                }
                else
                {
                    Console.WriteLine($"{firstNum} - {secondNum} = {result} - odd");
                }
            }
            else if (symbol == "*")
            {
                result = firstNum * secondNum;
                if (result % 2 == 0)
                {
                    Console.WriteLine($"{firstNum} * {secondNum} = {result} - even");
                }
                else
                {
                    Console.WriteLine($"{firstNum} * {secondNum} = {result} - odd");
                }
            }
            else if (symbol == "/")
            {
                if (secondNum==0)
                {
                    Console.WriteLine($"Cannot divide {firstNum} by zero");
                }
                else
                {
                result = firstNum / secondNum;
                Console.WriteLine($"{firstNum} / {secondNum} = {result:f2}");
                }
            }
            else if (symbol == "%")
            {
                if (secondNum == 0)
                {
                    Console.WriteLine($"Cannot divide {firstNum} by zero");
                }
                else
                {
                    result = firstNum % secondNum;
                    Console.WriteLine($"{firstNum} % {secondNum} = {result}");
                }
            }
        }
    }
}
