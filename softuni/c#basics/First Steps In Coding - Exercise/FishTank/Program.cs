using System;

namespace FishTank
{
    class Program
    {
        static void Main(string[] args)
        {
            int duljSm = int.Parse(Console.ReadLine());
            int shirSm = int.Parse(Console.ReadLine());
            int visSm = int.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());
            double obemAq =  0.001*(duljSm * shirSm * visSm);
            double zaetoPr = percent / 100;
            double litri = obemAq * (1 - zaetoPr);
            Console.WriteLine(litri);
        }
    }
}
