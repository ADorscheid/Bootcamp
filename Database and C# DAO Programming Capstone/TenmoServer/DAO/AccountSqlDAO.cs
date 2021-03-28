using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TenmoServer.Models;

namespace TenmoServer.DAO
{
    public class AccountSqlDAO : IAccountDAO
    {
        private readonly string connectionString;

        public AccountSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        // returns a list of accounts based on the username input
        public List<Account> GetAccounts(string username)
        {
            List<Account> accounts = new List<Account>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT a.user_id, a.account_id, a.balance FROM users u JOIN accounts a ON u.user_id = a.user_id WHERE u.username = @username", conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        accounts.Add(RowToObject(reader));

                    }
                }
                return accounts;
            }
            catch (SqlException)
            {
                throw;
            }
        }

        // returns an account based on the username and accountId input
        // used for displaying account balance in main menu
        public Account GetAccount(string username, int accountId)
        {
            Account account = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT a.user_id, a.account_id, a.balance FROM users u JOIN accounts a ON u.user_id = a.user_id WHERE u.username = @username AND a.account_id=@accountId", conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@accountId", accountId);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        account= RowToObject(reader);

                    }
                }
                return account;
            }
            catch (SqlException)
            {
                throw;
            }
            
        }

        // returns true if the money entered sucessfully was transferred
        public bool SendMoney(Transfer transfer)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("Begin Transaction; Update accounts set balance = balance-@transferAmount where account_id = @fromAccountId " +
                        "Update accounts set balance = balance + @transferAmount where account_id = @toAccountId; Commit transaction;", conn);
                    cmd.Parameters.AddWithValue("@fromAccountId", transfer.AccountFrom);
                    cmd.Parameters.AddWithValue("@toAccountId", transfer.AccountTo);
                    cmd.Parameters.AddWithValue("@transferAmount", transfer.Amount);

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }


        // helper method
        private static Account RowToObject(SqlDataReader reader)
        {
            Account account = new Account();
            account.UserId = Convert.ToInt32(reader["user_id"]);
            account.AccountId = Convert.ToInt32(reader["account_id"]);
            account.Balance = Convert.ToDecimal(reader["balance"]);
            return account;
        }
    }
}
