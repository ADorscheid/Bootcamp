using System;
using System.Collections.Generic;
using System.Text;

namespace Account
{
    public class CheckingAccount : Account
    {
        public decimal PerTransactionFee { get; }

        public CheckingAccount(string acctNum, decimal perTransFee) : base(acctNum, 0)
        {
            PerTransactionFee = perTransFee;
        }


    }
}
