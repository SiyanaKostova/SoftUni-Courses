using System;
using System.Text;

namespace _04._Caesar_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < message.Length; i++)
            {
                char encryptedChar = (char)(message[i] + 3);
                sb.Append(encryptedChar);
            }

            Console.WriteLine(sb);
        }
    }
}
