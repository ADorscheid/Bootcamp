using System;
using System.Collections.Generic;
using System.Text;

namespace Account
{
    public class SavingsAccount : Account
    {
        public SavingsAccount(string number, decimal bal) : base(number, bal)
        {
            //Console.WriteLine("In SavingsAccount constructor");
        }

        public override decimal Withdraw(decimal amtToWithdraw)
        {
            // Don't allow overdraw
            if (amtToWithdraw > Balance)
            {
                Console.WriteLine("ERROR! You don't have it!");
                return 0;
            }
            // I now know I have enough
            return base.Withdraw(amtToWithdraw);
        }

        public int GetRewardPoints()
        {
            return 1000;
        }

    }
}
