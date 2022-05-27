using System;

namespace _01._Sort_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstNum = double.Parse(Console.ReadLine());
            double secondNum = double.Parse(Console.ReadLine());
            double thirdNum = double.Parse(Console.ReadLine());

            if (firstNum>secondNum&&firstNum>thirdNum)
            {
                if (secondNum>thirdNum)
                {
                    Console.WriteLine(firstNum);
                    Console.WriteLine(secondNum);
                    Console.WriteLine(thirdNum);
                }
                else if (secondNum<thirdNum)
                {
                    Console.WriteLine(firstNum);
                    Console.WriteLine(thirdNum);
                    Console.WriteLine(secondNum);
                }
                else if (secondNum==thirdNum)
                {
                    Console.WriteLine(firstNum);
                    Console.WriteLine(secondNum);
                    Console.WriteLine(thirdNum);
                }
            }
            else if (secondNum > firstNum && secondNum > thirdNum)
            {
                if (firstNum > thirdNum)
                {
                    Console.WriteLine(secondNum);
                    Console.WriteLine(firstNum);
                    Console.WriteLine(thirdNum);
                }
                else if (firstNum < thirdNum)
                {
                    Console.WriteLine(secondNum);
                    Console.WriteLine(thirdNum);
                    Console.WriteLine(firstNum);
                }
                else if (firstNum == thirdNum)
                {
                    Console.WriteLine(secondNum);
                    Console.WriteLine(firstNum);
                    Console.WriteLine(thirdNum);
                }
            }
            else if (thirdNum > firstNum && thirdNum > secondNum)
            {
                if (firstNum > secondNum)
                {
                    Console.WriteLine(thirdNum);
                    Console.WriteLine(firstNum);
                    Console.WriteLine(secondNum);
                }
                else if (firstNum < secondNum)
                {
                    Console.WriteLine(thirdNum);
                    Console.WriteLine(secondNum);
                    Console.WriteLine(firstNum);
                }
                else if (firstNum == secondNum)
                {
                    Console.WriteLine(thirdNum);
                    Console.WriteLine(firstNum);
                    Console.WriteLine(secondNum);
                }
            }

        }
    }
}
