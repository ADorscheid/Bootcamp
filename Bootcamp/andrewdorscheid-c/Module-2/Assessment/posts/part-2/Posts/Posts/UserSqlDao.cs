using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Posts
{
    public class UserSqlDao : IUserDao
    {
        private readonly string connectionString;

        public UserSqlDao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<User> GetAllUsers()
        {
            // Implement this method to pull in all users from database

            return null;
        }

        public void Save(User newUser)
        {
            // Implement this method to save user to database
        }
    }
}