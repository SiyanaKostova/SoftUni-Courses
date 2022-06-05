using System;
using System.Linq;

namespace _02._Common_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr1 = Console.ReadLine().Split(' ');
            string[] arr2 = Console.ReadLine().Split(' ');
            foreach (string currElement in arr2)
            {
                for (int i = 0; i < arr1.Length; i++)
                {
                    string secCurrElement = arr1[i];
                    if (currElement==secCurrElement)
                    {
                        Console.Write($"{currElement} ");
                        break;
                    }
                }
            }
        }
    }
}
