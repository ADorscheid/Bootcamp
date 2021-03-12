using System.Collections.Generic;
using TenmoClient.Data;

namespace TenmoClient.DAL
{
    interface IUserApiDAO
    {
        List<API_User> GetUsers();
    }
}