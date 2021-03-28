using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TenmoServer.Models;

namespace TenmoServer.DAO
{
    public class TransferSqlDAO : ITransferDAO
    {
        private readonly string connectionString;

        public TransferSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }



        // returns a transfer with the new transferId added into the original transfer passed into this method
        // updates database with the new transfer
        public Transfer CreateTransfer(Transfer transfer)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO transfers (transfer_type_id, transfer_status_id, account_from, account_to, amount) VALUES (@transferType, @transferStatus, @accountfrom, @accountto, @amount); SELECT @@IDENTITY;", conn);
                    cmd.Parameters.AddWithValue("@accountfrom", transfer.AccountFrom);
                    cmd.Parameters.AddWithValue("@accountto", transfer.AccountTo);
                    cmd.Parameters.AddWithValue("@amount", transfer.Amount);
                    cmd.Parameters.AddWithValue("@transferType", transfer.TransferTypeId);
                    cmd.Parameters.AddWithValue("@transferStatus", transfer.TransferStatusId);
                    transfer.TransferId = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return transfer;
        }

        // returns a list of transfers the user is involved in (whether they sent or received the money)
        public List<Transfer> GetTransfers(string username)
        {
            List<Transfer> transfers = new List<Transfer>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = @"SELECT t.*, ufrom.username as AccountFromUsername, uto.username as AccountToUsername 
	                                FROM transfers t
	                                JOIN accounts afrom on t.account_from = afrom.account_id
	                                JOIN users ufrom on afrom.user_id = ufrom.user_id
	                                JOIN accounts ato on t.account_to = ato.account_id
	                                JOIN users uto on ato.user_id = uto.user_id
	                                WHERE account_from = (SELECT user_id from users WHERE username = @username) 
	                                Or account_to =(SELECT user_id from users WHERE username = @username) 
	                                ORDER BY transfer_id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Transfer transfer = RowToObject(rdr);
                        transfers.Add(transfer);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return transfers;
        }

        public Transfer UpdateTransfer(Transfer transfer)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("Update transfers set transfer_status_id=@statusId where transfer_id=@transferId;", conn);
                    cmd.Parameters.AddWithValue("@statusId", transfer.TransferStatusId);
                    cmd.Parameters.AddWithValue("@transferId", transfer.TransferId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return transfer;
        }

        // helper method
        private static Transfer RowToObject(SqlDataReader rdr)
        {
            Transfer transfer = new Transfer();
            transfer.AccountFrom = Convert.ToInt32(rdr["account_from"]);
            transfer.AccountTo = Convert.ToInt32(rdr["account_to"]);
            transfer.Amount = Convert.ToDecimal(rdr["amount"]);
            transfer.TransferId = Convert.ToInt32(rdr["transfer_id"]);
            transfer.TransferStatusId = Convert.ToInt32(rdr["transfer_status_id"]);
            transfer.TransferTypeId = Convert.ToInt32(rdr["transfer_type_id"]);
            transfer.AccountFromUsername = Convert.ToString(rdr["AccountFromUsername"]);
            transfer.AccountToUsername = Convert.ToString(rdr["AccountToUsername"]);
            return transfer;
        }
    }
}
