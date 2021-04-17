using System.Collections.Generic;

namespace Items
{
    public interface IUserDao
    {
        void Save(User newUser);
        IList<User> GetAllUsers();
    }
}