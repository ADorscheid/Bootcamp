using System;
using System.Collections.Generic;
using System.Text;

namespace Account
{
    // TODO 01: Should we be able to create an "Account" directly? i.e. is this really a concrete class?
    abstract public class Account
    {
        public string AccountNumber { get; set; }
        public decimal Balance { get; private set; }

        private List<string> transactionLog;
        // Transaction Log returns a copy as an array so that the caller cannot modify it.
        public string[] TransactionLog { 
            get
            {
                return transactionLog.ToArray();
            }
        }

        public Account(string accountNumber)
        {
            AccountNumber = accountNumber;
            Balance = 0.00m;

            // Create the empty transaction log
            transactionLog = new List<string>();
            transactionLog.Add($"Account {AccountNumber}: Created with Balance {Balance}.");
        }

        public Account(string accountNumber, decimal initialBalance)
        {
            //Console.WriteLine("In Account constructor");

            AccountNumber = accountNumber;
            Balance = initialBalance;

            // Create the empty transaction log
            transactionLog = new List<string>();
            transactionLog.Add($"Account {AccountNumber}: Created with Balance {Balance}.");
        }

        virtual public decimal Withdraw(decimal amtToWithdraw)
        {
            Balance -= amtToWithdraw;
            transactionLog.Add($"Account {AccountNumber}: Withdrawal of {amtToWithdraw:C}, remaining balance {Balance:C}.");

            return amtToWithdraw;
        }

        public decimal Deposit(decimal amtToDeposit)
        {
            Balance += amtToDeposit;
            transactionLog.Add($"Account {AccountNumber}: Deposit of {amtToDeposit:C}, new balance {Balance:C}.");

            return Balance;
        }

        public void TransferTo(decimal amount, Account toAccount)
        {
            decimal amtWithdrawn = this.Withdraw(amount);
            if (amtWithdrawn > 0)
            {
                toAccount.Deposit(amtWithdrawn);
            }
        }
    }
}
