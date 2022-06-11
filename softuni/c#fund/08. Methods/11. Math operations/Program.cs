using System;

namespace _11._Math_operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            string operationSign = Console.ReadLine();
            int secondNumber = int.Parse(Console.ReadLine());

            Console.WriteLine(Calculate(firstNumber, operationSign, secondNumber));
        }
        static double Calculate(int firstNumber, string operationSign, int secondNumber)
        {
            double result = 0;
            switch (operationSign)
            {
                case "/":
                    result = firstNumber / secondNumber;
                    break;
                case "*":
                    result = firstNumber * secondNumber;
                    break;
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    break;
            }
            return result;
        }
    }
}
