using System;

namespace YardGreening
{
    class Program
    {
        static void Main(string[] args)
        {
            double plosht = int.Parse(Console.ReadLine());
            double Cena = plosht * 7.61;
            double sale = Cena * 0.18;
            double final = Cena-sale;
            Console.WriteLine($"The final price is: {final} lv.");
            Console.WriteLine($"The discount is: {sale} lv.");
        }
    }
}
