using BankTellerExercise;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankTellerExerciseTests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void Constructor_TwoParameterTest()
        {
            // Arrange
            string name = "Aklile";
            string num = "123456";

            // Act - Call the 2-parameter constructor
            BankAccount account = new BankAccount(name, num);

            // Assert - Make sure holder, acct number and balance are all correct
            Assert.AreEqual(name, account.AccountHolderName);
            Assert.AreEqual(num, account.AccountNumber);
            Assert.AreEqual(0, account.Balance);

        }

        [TestMethod]
        public void TransferMoney()
        {
            // Arrange - Create two accounts for transferring money
            BankAccount account = new BankAccount("", "", 1000);
            BankAccount someOtherAccount = new BankAccount("", "", 10);


            // Act
            int transferredAmount = account.TransferTo(someOtherAccount, 600);


            //Assert - check the balances of both account
            Assert.AreEqual(600, transferredAmount, $"The TransferTo method should return the amount actually transferred (600). It actually returned {transferredAmount}");
            Assert.AreEqual(400, account.Balance);
            Assert.AreEqual(610, someOtherAccount.Balance);
        }
        [TestMethod]
        public void Constructor_TwoParameters_NullName_ShouldFailArgumentException()
        {
        }

            private int MySpecialMethod()
        {
            return 0;
        }
    }
}
