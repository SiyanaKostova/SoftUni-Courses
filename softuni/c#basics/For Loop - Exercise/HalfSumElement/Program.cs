using System;

namespace HalfSumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            int max = int.MinValue;
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                sum += num;
                if (num>max)
                {
                    max = num;
                }
            }
            int sumWithhoutMaxNumber = sum - max;
            if (max==sumWithhoutMaxNumber)
            {
                Console.WriteLine("Yes");
                Console.WriteLine("Sum = " + max);
            }
            else
            {
                int diff = Math.Abs(max - sumWithhoutMaxNumber);
                Console.WriteLine("No");
                Console.WriteLine("Diff = " + diff);
            }
        }
    }
}
