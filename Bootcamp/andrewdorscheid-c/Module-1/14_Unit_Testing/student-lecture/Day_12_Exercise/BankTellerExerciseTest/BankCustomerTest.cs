using System;
using System.Collections.Generic;
using System.Text;

using BankTellerExercise;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankTellerExerciseTest
{
    [TestClass]
    public class BankCustomerTest
    {
        [TestMethod]
        [DataRow("xxx","123")]
        public void getCustomerAccounts(string accountHolderName, string accountNumber) 
        {
            BankCustomer cust = new BankCustomer();
            SavingsAccount savings = new SavingsAccount(accountHolderName, accountNumber);
            CheckingAccount checking1 = new CheckingAccount(accountHolderName, accountNumber);
            CheckingAccount checking2 = new CheckingAccount(accountHolderName, accountNumber);
            IAccountable[] expectedAccounts = new IAccountable[] { savings,checking1,checking2};
            cust.AddAccount(savings);
            cust.AddAccount(checking2); 
            cust.AddAccount(checking1);
            

            IAccountable[] actualAccounts = cust.GetAccounts();


            //CollectionAssert.AreEqual(expectedAccounts, actualAccounts);
            CollectionAssert.AreEquivalent(expectedAccounts, actualAccounts);


        }
    }
}
