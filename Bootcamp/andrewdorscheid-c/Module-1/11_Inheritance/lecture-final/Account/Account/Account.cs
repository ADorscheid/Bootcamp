using System;
using System.Collections.Generic;
using System.Text;

namespace Account
{
    public class Account
    {
        public string AccountNumber { get; set; }
        public decimal Balance { get; private set; }


        public Account(string accountNumber, decimal initialBalance)
        {
            Console.WriteLine("In Account constructor");

            AccountNumber = accountNumber;
            Balance = initialBalance;
        }

        virtual public decimal Withdraw(decimal amtToWithdraw)
        {
            Balance -= amtToWithdraw;
            return amtToWithdraw;
        }

        public decimal Deposit(decimal amtToDeposit)
        {
            Balance += amtToDeposit;
            return Balance;
        }
    }
}
