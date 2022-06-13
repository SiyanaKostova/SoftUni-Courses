using System;
using System.Linq;

namespace _04._Password_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            bool isPassLengthValid = ValidePasswordLength(password);
            bool isPassContainingValidSymbols = ValidePasswordSymbols(password);
            bool isDigitInPassAtLeastTwo = ValidePasswordDigitCount(password);

            if (!isPassLengthValid)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
            if (!isPassContainingValidSymbols)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }
            if (!isDigitInPassAtLeastTwo)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }
            if (isPassLengthValid&&isPassContainingValidSymbols&&isDigitInPassAtLeastTwo)
            {
                Console.WriteLine("Password is valid");
            }
        }

        private static bool ValidePasswordDigitCount(string password)
        {
            int count = 0;
            foreach (char symbol in password)
            {
                if (char.IsDigit(symbol))
                {
                    count++;
                }
            }
            return count >= 2;
        }

        private static bool ValidePasswordSymbols(string password)
        {
            foreach (char symbol in password)
            {
                if (!char.IsLetterOrDigit(symbol))
                {
                    return false;
                }
            }
            return true;
        }

        private static bool ValidePasswordLength(string password)
        {
            return password.Length >= 6 && password.Length <= 10;
        }
    }
}
