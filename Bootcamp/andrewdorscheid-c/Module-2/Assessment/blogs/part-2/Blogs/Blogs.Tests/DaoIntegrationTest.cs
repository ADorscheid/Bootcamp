using System;
using System.Data.SqlClient;
using System.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blogs.Tests
{
    [TestClass]
    public abstract class DaoIntegrationTest
    {
        private TransactionScope transaction;

        protected string ConnectionString { get; } = @"Server=.\SQLEXPRESS;Database=assessment;Trusted_Connection=True;";

        [TestInitialize]
        public virtual void SetUp()
        {
            transaction = new TransactionScope();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "DELETE FROM posts";

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            transaction.Dispose();
        }

        protected int GetRowCount(string table)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"SELECT COUNT(*) FROM {table}", conn);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count;
            }
        }
    }
}
