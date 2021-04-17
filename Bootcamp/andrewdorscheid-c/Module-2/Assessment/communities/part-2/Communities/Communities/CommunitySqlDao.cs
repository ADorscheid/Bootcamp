using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Communities
{
    public class CommunitySqlDao : ICommunityDao
    {
        private readonly string connectionString;

        public CommunitySqlDao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<Community> GetAllCommunities()
        {
            // Implement this method to pull in all communities from database

            return null;
        }

        public void Save(Community newCommunity)
        {
            // Implement this method to save community to database
        }
    }
}