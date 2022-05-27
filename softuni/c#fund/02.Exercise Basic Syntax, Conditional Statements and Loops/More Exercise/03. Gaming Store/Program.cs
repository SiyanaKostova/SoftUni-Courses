using System;

namespace _03._Gaming_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string typeOfGame = "";
            double spendMoney = 0;

            while ((typeOfGame = Console.ReadLine()) != "Game Time")
            {
                if (typeOfGame == "OutFall 4")
                {
                    if (budget >= 39.99)
                    {
                        budget -= 39.99;
                        spendMoney += 39.99;
                        Console.WriteLine($"Bought {typeOfGame}");
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive"); 
                        continue;
                    }

                }
                else if (typeOfGame == "CS: OG")
                {
                    if (budget >= 15.99)
                    {
                        budget -= 15.99;
                        spendMoney += 15.99;
                        Console.WriteLine($"Bought {typeOfGame}");
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive"); 
                        continue;
                    }
                }
                else if (typeOfGame == "Zplinter Zell")
                {
                    if (budget >= 19.99)
                    {
                        budget -= 19.99;
                        spendMoney += 19.99;
                        Console.WriteLine($"Bought {typeOfGame}");
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive"); 
                        continue;
                    }
                }
                else if (typeOfGame == "RoverWatch")
                {
                    if (budget >= 29.99)
                    {
                        budget -= 29.99;
                        spendMoney += 29.99;
                        Console.WriteLine($"Bought {typeOfGame}");
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive"); 
                        continue;
                    }
                }
                else if (typeOfGame == "Honored 2")
                {
                    if (budget >= 59.99)
                    {
                        budget -= 59.99;
                        spendMoney += 59.99;
                        Console.WriteLine($"Bought {typeOfGame}");
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive"); 
                        continue;
                    }
                }
                else if (typeOfGame == "RoverWatch Origins Edition")
                {
                    if (budget >= 39.99)
                    {
                        budget -= 39.99;
                        spendMoney += 39.99;
                        Console.WriteLine($"Bought {typeOfGame}");
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive"); 
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Not Found");
                }
                if (budget <= 0)
                {
                    Console.WriteLine("Out of money!"); 
                    return;
                }
            }
            Console.WriteLine($"Total spent: ${spendMoney:f2}. Remaining: ${budget:f2}");
        }
    }
}
