using System.Collections.Generic;
using TenmoClient.Data;

namespace TenmoClient.DAL
{
    public interface ITransferDAO
    {
        List<Transfer> GetTransfers(string username);
        bool SendMoney(int fromUserId, int toUserId, decimal amount);
    }
}