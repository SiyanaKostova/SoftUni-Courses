using System;
using System.Collections.Generic;
using System.Linq;

class BankAccount
{
    public int Number { get; set; }
    public double Balance { get; set; }
}

class Program
{
    static void Main()
    {
        List<BankAccount> accounts = ReadAccounts();

        string command = Console.ReadLine();

        while (command != "End")
        {
            string[] commandParts = command.Split(' ');
            string action = commandParts[0];
            int accountNumber = int.Parse(commandParts[1]);
            double amount = double.Parse(commandParts[2]);

            BankAccount account = accounts.FirstOrDefault(a => a.Number == accountNumber);

            if (account == null)
            {
                Console.WriteLine("Invalid account!");
            }
            else if (action == "Deposit")
            {
                account.Balance += amount;
                Console.WriteLine($"Account {accountNumber} has new balance: {account.Balance:f2}");
            }
            else if (action == "Withdraw")
            {
                if (account.Balance < amount)
                {
                    Console.WriteLine("Insufficient balance!");
                }
                else
                {
                    account.Balance -= amount;
                    Console.WriteLine($"Account {accountNumber} has new balance: {account.Balance:f2}");
                }
            }
            else
            {
                Console.WriteLine("Invalid command!");
            }

            Console.WriteLine("Enter another command");
            command = Console.ReadLine();
        }
    }

    static List<BankAccount> ReadAccounts()
    {
        List<BankAccount> accounts = new List<BankAccount>();
        string input = Console.ReadLine();
        string[] accountData = input.Split(',');

        foreach (string data in accountData)
        {
            string[] accountParts = data.Split('-');
            int accountNumber = int.Parse(accountParts[0]);
            double accountBalance = double.Parse(accountParts[1]);
            BankAccount account = new BankAccount() { Number = accountNumber, Balance = accountBalance };
            accounts.Add(account);
        }

        return accounts;
    }
}