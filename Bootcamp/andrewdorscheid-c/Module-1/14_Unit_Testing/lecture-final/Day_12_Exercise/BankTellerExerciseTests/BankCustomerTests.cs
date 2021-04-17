using BankTellerExercise;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankTellerExerciseTests
{
    [TestClass]
    public class BankCustomerTests
    {

        [TestMethod]
        public void GetCustomerAccounts()
        {
            // Arrange - Create a customer plus some accounts for that customer
            BankCustomer cust = new BankCustomer();

            SavingsAccount savings = new SavingsAccount("xxx", "123");
            CheckingAccount checking1 = new CheckingAccount("xxx", "123");
            CheckingAccount checking2 = new CheckingAccount("xxx", "123");

            cust.AddAccount(checking1);
            cust.AddAccount(checking2);
            cust.AddAccount(savings);

            // Act - call GetAccounts
            IAccountable[] actualAccounts = cust.GetAccounts();


            // Assert - verify all accounts are returned
            IAccountable[] expectedAccounts = new IAccountable[] { savings, checking1, checking2 };
            //CollectionAssert.AreEqual(expectedAccounts, actualAccounts);
            CollectionAssert.AreEquivalent(expectedAccounts, actualAccounts);
        }
    }
}
