using System;

namespace _08._Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double biggestKeg = double.MinValue;
            string biggestKegName = "";

            for (int i = 0; i < n; i++)
            {
                string model = Console.ReadLine();
                float radius = float.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                double volumeOfCurrKeg = Math.PI * Math.Pow(radius, 2) * height;
                if (volumeOfCurrKeg>biggestKeg)
                {
                    biggestKeg = volumeOfCurrKeg;
                    biggestKegName = model;
                }
            }
            Console.WriteLine(biggestKegName);
            

        }
    }
}
