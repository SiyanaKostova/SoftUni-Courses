using System;

namespace _10._Rage_Expenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfLostGames = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            double numberBrokenHeadsets = Math.Floor(countOfLostGames / 2.0);
            double numberBrokenMice = Math.Floor(countOfLostGames / 3.0);
            double numberBrokenKB = Math.Floor(countOfLostGames / 6.0);
            double numberBrokenD = Math.Floor(countOfLostGames / 12.0);

            double totalHeadsetPrice = numberBrokenHeadsets * headsetPrice;
            double totalMicePrice = numberBrokenMice * mousePrice;
            double totalKeyboardPrice = numberBrokenKB * keyboardPrice;
            double totalDisplayPrice = numberBrokenD * displayPrice;

            double totalExpenses = totalHeadsetPrice + totalMicePrice + totalKeyboardPrice + totalDisplayPrice;
            Console.WriteLine($"Rage expenses: {totalExpenses:f2} lv.");

        }
    }
}
