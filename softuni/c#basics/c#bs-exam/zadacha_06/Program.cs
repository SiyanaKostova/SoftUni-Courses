using System;

namespace zadacha_06
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int a, b, c, d;
            bool isFound = false;
            for (int i = 1; i <= 9; i++)
            {
                a = i;
                for (int j = 9; j >= a; j--)
                {
                    b = j;
                    for (int k = 1; k <= 9; k++)
                    {
                        c = k;
                        for (int l = 8; l >= c; l--)
                        {
                            d = l;

                            int sum = a + b + c + d;
                            int multiply = a * b * c * d;
                            int lastDigitn = n % 10;

                            if (sum == multiply && lastDigitn == 5)
                            {
                                Console.Write(a);
                                Console.Write(b);
                                Console.Write(c);
                                Console.Write(d);
                                isFound = true;
                                return;
                            }
                            else if (multiply / sum == 3 && n % 3 == 0)
                            {
                                Console.Write(d);
                                Console.Write(c);
                                Console.Write(b);
                                Console.Write(a);
                                isFound = true;
                                return;
                            }
                        }
                    }
                }
            }
            if (!isFound)
            {
                Console.WriteLine("Nothing found");
            }
        }
    }
}
