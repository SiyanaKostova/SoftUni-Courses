using System;

namespace OddEvenSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int countNum = int.Parse(Console.ReadLine());
            double chetnaSum = 0;
            double neChetnaSum = 0; 
            for (int i = 0; i < countNum; i++)
            {
                double num = double.Parse(Console.ReadLine());
                if (i%2==0)
                {
                    chetnaSum += num;
                }
                else
                {
                    neChetnaSum += num;
                }
            }
            double difference = Math.Abs(chetnaSum - neChetnaSum);
            if (chetnaSum==neChetnaSum)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {chetnaSum}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {difference}");
            }
        }
    }
}
