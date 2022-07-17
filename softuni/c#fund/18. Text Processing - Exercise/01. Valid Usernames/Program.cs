using System;
using System.Collections.Generic;

namespace _01._Valid_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            List<string> validUsernames = new List<string>();

            foreach (var username in usernames)
            {
                if (username.Length >= 3 && username.Length <= 16)
                {
                    bool isUsernameValid = true;

                    for (int i = 0; i < username.Length; i++)
                    {
                        char currentChar = username[i];

                        if (!(currentChar == '-' || currentChar == '_' || char.IsLetterOrDigit(currentChar))) 
                        {
                            isUsernameValid = false;
                            break;
                        }
                    }
                    if (isUsernameValid)
                    {
                        validUsernames.Add(username);
                    }
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, validUsernames));
        }
    }
}
