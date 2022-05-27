using System;

namespace SuppliesForSchool
{
    class Program
    {
        static void Main(string[] args)
        { 
            int broiPaketiHimikali = int.Parse(Console.ReadLine());
            int broiPaketiMarkeri = int.Parse(Console.ReadLine());
            int broiLitriPreparat = int.Parse(Console.ReadLine());
            int procentNamalemie = int.Parse(Console.ReadLine());

            double priceHimikali = broiPaketiHimikali * 5.80;
            double priceMarkeri = broiPaketiMarkeri * 7.20;
            double pricePreparat = broiLitriPreparat * 1.20;

            double sum = priceHimikali + priceMarkeri + pricePreparat;
            double sumAfterDiscount = sum - (procentNamalemie/100.0) * sum;
            Console.WriteLine(sumAfterDiscount);
        }
    }
}
