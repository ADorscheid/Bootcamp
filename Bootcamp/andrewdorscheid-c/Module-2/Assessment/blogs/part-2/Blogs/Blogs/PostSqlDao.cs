using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Blogs
{
    public class PostSqlDao : IPostDao
    {
        private readonly string connectionString;

        public PostSqlDao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<Post> GetAllPosts()
        {
            // Implement this method to pull in all posts from database

            return null;
        }

        public void Save(Post newPost)
        {
            // Implement this method to save post to database
        }
    }
}