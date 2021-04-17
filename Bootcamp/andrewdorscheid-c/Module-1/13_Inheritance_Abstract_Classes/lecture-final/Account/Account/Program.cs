using System;
using System.Collections.Generic;

namespace Account
{
    class Program
    {
        static void Main(string[] args)
        {
            // Cannot do this because Account has been marked "abstract"
            // Account account = new Account("3456");

            int bigNumber = 1000000000;
            byte smallNumber = (byte)bigNumber;

            SavingsAccount savings = new SavingsAccount("1234", 1000.00M);
            CheckingAccount checking = new CheckingAccount("9876", 0.50M);

            // POLYMORPHISM: We are storing subclasses in a collection declared for the superclass
            List<Account> accounts = new List<Account>() { savings, checking };

            // End of month....Hit'em with some fees
            foreach (Account acct in accounts)
            {
                // POLYMORPHISM: the appropriate method gets called based on the *runtime type*, not the *declared type*
                acct.Withdraw(10.00M);
            }

            // Bank-lotto: Add a random amount to each account
            Random random = new Random();

            foreach (Account acct in accounts)
            {
                int amount = random.Next(10, 150);
                acct.Deposit(amount);
            }

            // POLYMORPHISM: the method expects an Account, we send it a CheckingAccount
            savings.TransferTo(150, checking);


            // POLYMORPHISM: the method expects an Account, we send it a SavingsAccount or CheckingAccount
            PrintMonthlyStatement(savings);
            PrintMonthlyStatement(checking);

        }

        /// <summary>
        /// Print a monthly statement for an account
        /// </summary>
        /// <param name="acct">The Account to print the statement for</param>
        private static void PrintMonthlyStatement(Account acct)
        {
            Console.WriteLine(
$@"
=============================================================================
                               Account Statement
=============================================================================
Account Number: {acct.AccountNumber}
Account Balance: {acct.Balance}

Transaction Log:
");

            foreach (string logEntry in acct.TransactionLog)
            {
                Console.WriteLine($"\t{logEntry}");
            }
            Console.WriteLine("=============================================================================");
        }

    }
}
