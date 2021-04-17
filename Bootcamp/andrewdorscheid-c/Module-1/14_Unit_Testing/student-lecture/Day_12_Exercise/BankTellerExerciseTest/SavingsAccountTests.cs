using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

using BankTellerExercise;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankTellerExerciseTest
{   
    [TestClass]
    public class SavingsAccountTests
    {
        

        [TestMethod]
        public void TestArray() 
        {
            int[] initArray = new int[] { 1,2,3};
            int[] expectedArray = new int[] {1,2,3 };
//            Assert.AreEqual(initArray,expectedArray);//this compares the reference/memoryAddress, which will fail
            CollectionAssert.AreEqual(initArray,expectedArray);
            CollectionAssert.AreEquivalent(initArray, expectedArray);  //doesnt care about order
        }
        [DataTestMethod]
        [DataRow(500,100,400,DisplayName ="happy path")]
        [DataRow(500,350, 150)]
        [DataRow(500, 351, 147,DisplayName ="edge case, balance goes < 150")]
        [DataRow(500, 500, 500)]
        [DataRow(500, 499, 500)]
        [DataRow(500, 498, 0)]
        public void testWithdraw(int startingBalance, int withdrawalAmount, int expectedNewBalance) {
            SavingsAccount savingsAccount = new SavingsAccount("Ben","1234",startingBalance);

            int returnValue = savingsAccount.Withdraw(withdrawalAmount);

            Assert.AreEqual(expectedNewBalance, returnValue);
            Assert.AreEqual(expectedNewBalance, savingsAccount.Balance);
        }

/*        [TestMethod]
        public void testWithdraw_balanceGoesBelow150() {
            SavingsAccount savingsAccount = new SavingsAccount("Ben", "1234", 500);

            int returnValue = savingsAccount.Withdraw(351);

            Assert.AreEqual(148, returnValue);
            Assert.AreEqual(148, savingsAccount.Balance);
        }*/
    }
}
