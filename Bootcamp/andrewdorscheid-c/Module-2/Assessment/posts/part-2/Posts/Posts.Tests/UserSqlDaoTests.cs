using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Posts.Tests
{
    [TestClass]
    public class UserSqlDaoTests : DaoIntegrationTest
    {
        private UserSqlDao subject;

        [TestInitialize]
        public override void SetUp()
        {
            base.SetUp();
            subject = new UserSqlDao(ConnectionString);
        }

        [TestMethod]
        public void SaveAddsARow()
        {
            User newUser = new User
            {
                Created = new DateTime(2019, 10, 20),
                Email = "TEST email",
                FirstName = "TEST first name",
                LastName = "TEST last name",
                Role = "role"
            };

            subject.Save(newUser);

            Assert.AreEqual(1, GetRowCount("users"));
        }

        [TestMethod]
        public void SaveAddsAllUserData()
        {
            User newUser = new User
            {
                Created = new DateTime(2019, 10, 20),
                Email = "TEST email",
                FirstName = "TEST first name",
                LastName = "TEST last name",
                Role = "role"
            };

            subject.Save(newUser);

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"
                    SELECT id, first_name, last_name, email, role, created
                    FROM users
                    WHERE id = (SELECT MAX(id) FROM users)";

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Assert.AreEqual(newUser.Created, (DateTime)reader["created"]);
                    Assert.AreEqual(newUser.Id, (int)reader["id"]);
                    Assert.AreEqual(newUser.Email, reader["email"] as string);
                    Assert.AreEqual(newUser.FirstName, reader["first_name"] as string);
                    Assert.AreEqual(newUser.LastName, reader["last_name"] as string);
                    Assert.AreEqual(newUser.Role, reader["role"] as string);
                }
                else
                {
                    Assert.Fail("There were no rows in the users table after Save method was called");
                }
            }
        }

        [TestMethod]
        public void GetAllUsersReturnsAllUsers()
        {
            InsertTestUsers(5);
            IList<User> actualUsers = subject.GetAllUsers();
            Assert.AreEqual(5, actualUsers.Count);
        }

        [TestMethod]
        public void GetAllUsersReturnsUserData()
        {
            InsertTestUsers(1);
            IList<User> actualUsers = subject.GetAllUsers();

            Assert.AreEqual(1, actualUsers.Count);
            User actualUser = actualUsers.First();
            Assert.IsNotNull(actualUser);
            Assert.AreEqual(new DateTime(2019, 10, 1), actualUser.Created);
            Assert.AreEqual("TEST email 1", actualUser.Email);
            Assert.AreEqual("TEST first name 1", actualUser.FirstName);
            Assert.AreEqual("TEST last name 1", actualUser.LastName);
            Assert.AreEqual("role 1", actualUser.Role);
        }

        private void InsertTestUsers(int numberOfUsers)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string insertStatements = string.Empty;
                for (int i = 1; i <= numberOfUsers; i++)
                {
                    insertStatements += $@"
                        INSERT INTO users (first_name, last_name, email, role, created)
                        VALUES ('TEST first name {i}', 'TEST last name {i}', 'TEST email {i}', 'role {i}', '2019-10-{i}')";
                }

                SqlCommand command = connection.CreateCommand();
                command.CommandText = insertStatements;

                connection.Open();

                command.ExecuteNonQuery();
            }
        }
    }
}
