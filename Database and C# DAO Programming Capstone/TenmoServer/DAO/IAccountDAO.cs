using System.Collections.Generic;
using TenmoServer.Models;

namespace TenmoServer.DAO
{
    public interface IAccountDAO
    {
        List<Account> GetAccounts(string username);
        //List<Account> GetAccounts(); // implent this if i want to put an admin in to see all accounts and their balances
        Account GetAccount(string username, int accountId);
        bool SendMoney(Transfer transfer);
    }
}