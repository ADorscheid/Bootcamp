using System.Collections.Generic;
using TenmoServer.Models;

namespace TenmoServer.DAO
{
    public interface IUserDAO
    {
        User GetUserByName(string username);
        User AddUser(string username, string password);
        List<User> GetUsers();
    }
}
