using System;
using System.Collections.Generic;

namespace Account
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Account> accounts = new List<Account>();

            SavingsAccount savings = new SavingsAccount("1234", 1000.00M);
            CheckingAccount checking = new CheckingAccount("9876", 0.50M);

            accounts.Add(savings);
            accounts.Add(checking);


            savings.Deposit(500.23M);

            // End of month....Hit'em with some fees
            foreach(Account a in accounts)
            {
                a.Withdraw(10.00M);
                Console.WriteLine($"Account {a.AccountNumber} has {a.Balance:C}");
            }



        }
    }
}
