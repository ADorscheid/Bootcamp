using System;
using System.Collections.Generic;
using System.Text;

namespace Account
{
    public class Account
    {
        public string AccountNumber { get; set; }
        public decimal Balance { get; private set; }

        // TODO 05: Change the Transaction Log so that the caller cannot modify it.
        public List<string> TransactionLog { get; private set; }

        public Account(string accountNumber, decimal initialBalance)
        {
            //Console.WriteLine("In Account constructor");

            AccountNumber = accountNumber;
            Balance = initialBalance;

            // Create the empty transaction log
            TransactionLog = new List<string>();
            TransactionLog.Add($"Account {AccountNumber}: Created with Balance {Balance}.");
        }

        virtual public decimal Withdraw(decimal amtToWithdraw)
        {
            Balance -= amtToWithdraw;
            TransactionLog.Add($"Account {AccountNumber}: Withdrawal of {amtToWithdraw:C}, remaining balance {Balance:C}.");

            return amtToWithdraw;
        }

        public decimal Deposit(decimal amtToDeposit)
        {
            Balance += amtToDeposit;
            TransactionLog.Add($"Account {AccountNumber}: Deposit of {amtToDeposit:C}, new balance {Balance:C}.");

            return Balance;
        }

        // TODO 01: Add a Transfer method to the Account class. What Type is its "toAccount" parameter?

    }
}
