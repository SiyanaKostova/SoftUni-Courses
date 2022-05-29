using System;

namespace _04._Refactoring___Prime_Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            int finalN = int.Parse(Console.ReadLine());
            for (int firstNum = 2; firstNum <= finalN; firstNum++)
            {
                string isPrimeNumber = "true";

                for (int number = 2; number < firstNum; number++)
                {
                    if (firstNum % number == 0)
                    {
                        isPrimeNumber = "false";
                        break;
                    }
                }
                Console.WriteLine($"{firstNum} -> {isPrimeNumber}");
            }

        }
    }
}
