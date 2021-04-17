using System.Collections.Generic;

namespace Posts
{
    public interface IUserDao
    {
        void Save(User newUser);
        IList<User> GetAllUsers();
    }
}