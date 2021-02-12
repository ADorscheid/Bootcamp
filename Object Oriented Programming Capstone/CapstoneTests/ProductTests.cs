using Capstone;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class ProductTests
    {

        [TestMethod]
        public void TestProductConstructorName()
        {
            //Arrange
            Product sampleProduct = new Product("Crunchy Crisps", 3.05, "Chip");

            //Act

            //Assert
            Assert.AreEqual("Crunchy Crisps", sampleProduct.Name);

        }

        [TestMethod]
        public void TestProductConstructorPrice()
        {
            //Arrange
            Product sampleProduct = new Product("Crunchy Crisps", 3.05, "Chip");

            //Act

            //Assert
            Assert.AreEqual(3.05, sampleProduct.Price);

        }

        [TestMethod]
        public void TestProductConstructorType()
        {
            //Arrange
            Product sampleProduct = new Product("Crunchy Crisps", 3.05, "Chip");

            //Act

            //Assert
            Assert.AreEqual("Chip", sampleProduct.Type);

        }
    }
}
