using System;
using System.Collections.Generic;
using System.Text;

using BankTellerExercise;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankTellerExerciseTest 
{
    [TestClass]
    public class BankAccountTest 
    {
        [TestMethod]
        public void Constructor_TwoParameterTest() 
        {
            string expectedAccountHolderName = "Ben";
            string expectedAccountNumber = "123456";

            //run the test
            BankAccount bankAccount = new BankAccount(expectedAccountHolderName, expectedAccountNumber);

            //Assert - make sure holder name, number and balance are correct
            Assert.AreEqual(expectedAccountHolderName, bankAccount.AccountHolderName);
            Assert.AreEqual(expectedAccountNumber, bankAccount.AccountNumber);
            Assert.AreEqual(0, bankAccount.Balance);
        }
        
        [TestMethod]
        public void TransferMoneyTest () 
        {
            //Arrange

            //Act

            //Assert

        }
    }
}
