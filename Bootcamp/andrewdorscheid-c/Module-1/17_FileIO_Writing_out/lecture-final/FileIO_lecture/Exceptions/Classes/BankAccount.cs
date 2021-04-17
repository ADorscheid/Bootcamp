using System;
using System.Collections.Generic;
using System.Text;

namespace Exceptions.Classes
{
    public class BankAccount
    {
        public string AccountNumber { get;}
        public decimal Balance { get; private set; }

        public BankAccount(decimal intialBalance)
        {
            this.AccountNumber = Guid.NewGuid().ToString();
            this.Balance = intialBalance;
        }

        public void Deposit(decimal amount)
        {
            this.Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            this.Balance -= amount;
        }

        public override string ToString()
        {
            return $"Account {AccountNumber}: Balance = {Balance:C}";
        }
    }
}
