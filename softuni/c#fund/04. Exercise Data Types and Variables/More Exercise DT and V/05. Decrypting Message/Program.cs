using System;

namespace _05._Decrypting_Message
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int nLines = int.Parse(Console.ReadLine());

            string result = "";
            int sum = 0;

            for (int i = 0; i < nLines; i++)
            {
                char symbol = char.Parse(Console.ReadLine());

                sum = (int)symbol + key;
                result = result + (char)sum;

            }
            Console.Write(result);
        }
    }
}
