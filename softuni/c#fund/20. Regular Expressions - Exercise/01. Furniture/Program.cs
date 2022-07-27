using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01._Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @">>(?<name>[A-Za-z\s]+)<<(?<price>\d+(.\d+)?)!(?<quantity>\d+)";

            string input = Console.ReadLine();

            List<string> list = new List<string>();

            double totalPrice = 0;

            while (input != "Purchase")
            {
                Match matches = Regex.Match(input, regex, RegexOptions.IgnoreCase);
                if (matches.Success)
                {
                    var name = matches.Groups["name"].Value;
                    var price = double.Parse(matches.Groups["price"].Value);
                    var quantity = int.Parse(matches.Groups["quantity"].Value);
                    list.Add(name);
                    totalPrice += price * quantity;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine("Bought furniture:");
            list.ForEach(Console.WriteLine);
            Console.WriteLine($"Total money spend: {totalPrice:f2}");
        }
    }
}
