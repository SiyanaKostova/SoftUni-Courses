using System;

namespace _01._Day_of_Week
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] daysOfWeek = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"};
            int index = int.Parse(Console.ReadLine());
            if (index>0&&index<8)
            {
                Console.WriteLine(daysOfWeek[index - 1]);
            }
            else
            {
                Console.WriteLine("Invalid day!");
            }
            
        }
    }
}
