using System;

namespace basketballEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            int taksa = int.Parse(Console.ReadLine());
            double kecove = taksa-0.4*taksa;
            double ekip = kecove-0.2*kecove;
            double topka = ekip/4;
            double aksesoari = topka/5;

            double sum = taksa + kecove + ekip + topka + aksesoari;
            Console.WriteLine(sum);
        }
    }
}
