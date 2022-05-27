using System;

namespace VacationBooksList
{
    class Program
    {
        static void Main(string[] args)
        {
            int broiStrKniga = int.Parse(Console.ReadLine());
            int straniciZaChas = int.Parse(Console.ReadLine());
            int broiDni = int.Parse(Console.ReadLine());
            double chasNaDen = (broiStrKniga / straniciZaChas) / broiDni;
            Console.WriteLine(chasNaDen);
        }
    }
}
