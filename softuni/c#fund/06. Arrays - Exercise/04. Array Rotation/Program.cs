using System;
using System.Linq;

namespace _04._Array_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rotations = int.Parse(Console.ReadLine());

            for (int rotation = 0; rotation < rotations; rotation++)
            {
                int tempElement = arr[0];
                for (int operation = 0; operation < arr.Length-1; operation++)
                {
                    arr[operation] = arr[operation + 1];
                }
                arr[arr.Length - 1] = tempElement;
            }
            Console.WriteLine(string.Join(" ", arr));
        }
    }
}
