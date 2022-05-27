using System;

namespace Min_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int minNum = int.MaxValue;
            while (input != "Stop")
            {
                int num = int.Parse(input);
                input = Console.ReadLine();
                if (num < minNum)
                {
                    minNum = num;
                }
            }
            Console.WriteLine(minNum);
        }
    }
}
