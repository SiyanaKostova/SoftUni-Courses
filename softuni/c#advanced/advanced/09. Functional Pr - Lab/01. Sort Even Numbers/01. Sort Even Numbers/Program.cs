﻿using System;
using System.Linq;
using System.Collections.Generic;

namespace MyApp 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Where(x => x % 2 == 0).OrderBy(x => x).ToArray();
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}