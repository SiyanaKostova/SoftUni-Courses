﻿using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _05._Nether_Realms
{
    class Program
    {
        static void Main(string[] args)
        {
            string healthPattern = @"[^\+\-\*\/\.,0-9]";
            string damagePattern = @"-?\d+\.?\d*";
            string multiplyOrDivideDamagePattern = @"[\*\/]";
            string splitPatttern = @"[,\s]+";

            string input = Console.ReadLine();
            string[] demons = Regex.Split(input, splitPatttern).OrderBy(x => x).ToArray();

            for (int i = 0; i < demons.Length; i++)
            {
                string currentDemon = demons[i];

                var healthMatched = Regex.Matches(currentDemon, healthPattern);
                var health = 0;
                foreach (Match match in healthMatched)
                {
                    char currentChar = char.Parse(match.ToString());
                    health += currentChar;
                }

                double damage = 0;
                var damageMatched = Regex.Matches(currentDemon, damagePattern);
                foreach (Match match in damageMatched)
                {
                    double currentDamage = double.Parse(match.ToString());
                    damage += currentDamage;
                }

                var multiplyAndDividers = Regex.Matches(currentDemon, multiplyOrDivideDamagePattern);
                foreach (Match match in multiplyAndDividers)
                {
                    char currentOperator = char.Parse(match.ToString());
                    if (currentOperator == '*')
                    {
                        damage *= 2;
                    }
                    else
                    {
                        damage /= 2;
                    }
                }
                Console.WriteLine($"{currentDemon} - {health} health, {damage:f2} damage");
            }
        }
    }
}
