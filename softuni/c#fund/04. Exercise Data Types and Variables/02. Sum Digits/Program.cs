using System;

namespace _02._Sum_Digits
{
    class Program
    {
        static void Main(string[] args)
        {
            ////first attempt to solve the problem:
            //int numInput = int.Parse(Console.ReadLine());
            //int sum = 0;

            //while (numInput!=0)
            //{
            //    int lastDigit = numInput % 10;
            //    sum += lastDigit;
            //    numInput /= 10;
            //}
            //Console.WriteLine(sum);


            //second attempt to solve the problem:
            string input = Console.ReadLine();
            char[] charArray = input.ToCharArray();
            int sum = 0;

            for (int value = 0; value < charArray.Length; value++)
            {
                sum += int.Parse(charArray[value].ToString());
            }
            Console.WriteLine(sum);
        }
    }
}
