using System;

namespace _10._Multiply_Evens_by_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            number = Math.Abs(number);

            int evenSum = GetSumEvenDigits(number);
            int oddSum = GetSumOddDigits(number);
            int result = GetMultibleOfEvenAndOdd(evenSum, oddSum);
            Console.WriteLine(result);
            
        }
        static int GetSumEvenDigits(int number)
        {
            int sum = 0;
            int digits = number;

            while (digits>0)
            {
                int currentDigit = digits % 10;
                if (currentDigit%2==0)
                {
                    sum += currentDigit;
                }
                digits /= 10;
            }
            return sum;
        }
        static int GetSumOddDigits(int number)
        {
            int sum = 0;
            int digits = number;

            while (digits > 0)
            {
                int currentDigit = digits % 10;
                if (currentDigit % 2 != 0)
                {
                    sum += currentDigit;
                }
                digits /= 10;
            }
            return sum;
        }
        static int GetMultibleOfEvenAndOdd(int evenSum, int oddSum)
        {
            return evenSum * oddSum;
        }
    }
}
