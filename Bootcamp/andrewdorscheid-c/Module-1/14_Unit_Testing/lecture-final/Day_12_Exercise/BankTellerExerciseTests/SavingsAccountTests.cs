using BankTellerExercise;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankTellerExerciseTests
{
    [TestClass]
    public class SavingsAccountTests
    {
        [DataTestMethod]
        [DataRow(500, 100, 400, DisplayName = "Happy path withdrawal")]
        [DataRow(500, 350, 150)]
        [DataRow(500, 351, 147, DisplayName = "Edge case, balance goes to <150, another $2 withdrawn")]
        [DataRow(500, 500, 500)]
        [DataRow(500, 499, 500)]
        [DataRow(500, 498, 0)]
        public void Withdraw(int startingBalance, int withdrawalAmount, int expectedNewBalance)
        {
            // Arrange
            // Create a savings account with an initial balance
            SavingsAccount account = new SavingsAccount("Holder", "1234", startingBalance);

            // Act
            // Call the Withdraw method
            int returnValue = account.Withdraw(withdrawalAmount);


            // Assert
            // Verify the return value
            Assert.AreEqual(expectedNewBalance, returnValue);

            // Verify the new balnce is correct
            Assert.AreEqual(expectedNewBalance, account.Balance);
        }

        //[TestMethod]
        //public void Withdraw_BalanceReaches150()
        //{
        //    // Arrange
        //    // Create a savings account with an initial balance
        //    SavingsAccount account = new SavingsAccount("Holder", "1234", 500);

        //    // Act
        //    // Call the Withdraw method
        //    int returnValue = account.Withdraw(350);


        //    // Assert
        //    // Verify the return value
        //    Assert.AreEqual(150, returnValue);

        //    // Verify the new balnce is correct
        //    Assert.AreEqual(150, account.Balance);
        //}

        //[TestMethod]
        //public void TestArray()
        //{
        //    // Arrange
        //    int[] initArray = new int[] { 1, 2, 3 };

        //    // Act 
        //    int[] resultArray = BeginEnd(initArray);

        //    int[] expectedArray = new int[] { 3, 2, 1 };

        //    CollectionAssert.AreEqual(expectedArray, resultArray);
        //    CollectionAssert.AreEquivalent(expectedArray, resultArray);
        //}
    }
}
