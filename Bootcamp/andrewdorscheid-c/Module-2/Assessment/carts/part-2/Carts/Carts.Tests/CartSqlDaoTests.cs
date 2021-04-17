using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Carts.Tests
{
    [TestClass]
    public class CartSqlDaoTests : DaoIntegrationTest
    {
        private CartSqlDao subject;

        [TestInitialize]
        public override void SetUp()
        {
            base.SetUp();
            subject = new CartSqlDao(ConnectionString);
        }

        [TestMethod]
        public void SaveAddsARow()
        {
            Cart newCart = new Cart
            {
                CookieValue = "TEST cookie_value",
                Created = new DateTime(2019, 10, 20),
                Username = "TEST username"
            };

            subject.Save(newCart);

            Assert.AreEqual(1, GetRowCount("carts"));
        }

        [TestMethod]
        public void SaveAddsAllCartData()
        {
            Cart newCart = new Cart
            {
                CookieValue = "TEST cookie_value",
                Created = new DateTime(2019, 10, 20),
                Username = "TEST username"
            };

            subject.Save(newCart);

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"
                    SELECT id, cookie_value, username, created
                    FROM carts
                    WHERE id = (SELECT MAX(id) FROM carts)";

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Assert.AreEqual(newCart.CookieValue, reader["cookie_value"] as string);
                    Assert.AreEqual(newCart.Created, (DateTime)reader["created"]);
                    Assert.AreEqual(newCart.Id, (int)reader["id"]);
                    Assert.AreEqual(newCart.Username, reader["username"] as string);
                }
                else
                {
                    Assert.Fail("There were no rows in the carts table after Save method was called");
                }
            }
        }

        [TestMethod]
        public void GetAllCartsReturnsAllCarts()
        {
            InsertTestCarts(5);
            IList<Cart> actualCarts = subject.GetAllCarts();
            Assert.AreEqual(5, actualCarts.Count);
        }

        [TestMethod]
        public void GetAllCartsReturnsCartData()
        {
            InsertTestCarts(1);
            IList<Cart> actualCarts = subject.GetAllCarts();

            Assert.AreEqual(1, actualCarts.Count);
            Cart actualCart = actualCarts.First();
            Assert.IsNotNull(actualCart);
            Assert.AreEqual("TEST cookie_value 1", actualCart.CookieValue);
            Assert.AreEqual(new DateTime(2019, 10, 1), actualCart.Created);
            Assert.AreEqual("TEST username 1", actualCart.Username);
        }

        private void InsertTestCarts(int numberOfCarts)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string insertStatements = string.Empty;
                for (int i = 1; i <= numberOfCarts; i++)
                {
                    insertStatements += $@"
                        INSERT INTO carts(username, cookie_value, created) 
                        VALUES ('TEST username {i}', 'TEST cookie_value {i}', '2019-10-{i}')";
                }

                SqlCommand command = connection.CreateCommand();
                command.CommandText = insertStatements;

                connection.Open();

                command.ExecuteNonQuery();
            }
        }
    }
}
