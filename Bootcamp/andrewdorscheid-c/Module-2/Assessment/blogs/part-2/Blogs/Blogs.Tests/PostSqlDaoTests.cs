using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blogs.Tests
{
    [TestClass]
    public class PostSqlDaoTests : DaoIntegrationTest
    {
        private PostSqlDao subject;

        [TestInitialize]
        public override void SetUp()
        {
            base.SetUp();
            subject = new PostSqlDao(ConnectionString);
        }

        [TestMethod]
        public void SaveAddsARow()
        {
            Post newPost = new Post
            {
                Body = "TEST BODY",
                Created = new DateTime(2019, 10, 20),
                Name = "TEST NAME",
                IsPublished = true
            };

            subject.Save(newPost);

            Assert.AreEqual(1, GetRowCount("posts"));
        }

        [TestMethod]
        public void SaveAddsAllPostData()
        {
            Post newPost = new Post
            {
                Body = "TEST BODY",
                Created = new DateTime(2019, 10, 20),
                Name = "TEST NAME",
                IsPublished = true
            };

            subject.Save(newPost);

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"
                    SELECT id, body, name, created, published
                    FROM posts
                    WHERE id = (SELECT MAX(id) FROM posts)";

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Assert.AreEqual(newPost.Body, reader["body"] as string);
                    Assert.AreEqual(newPost.Created, (DateTime)reader["created"]);
                    Assert.AreEqual(newPost.Id, (int)reader["id"]);
                    Assert.AreEqual(newPost.IsPublished, (bool)reader["published"]);
                    Assert.AreEqual(newPost.Name, reader["name"] as string);
                }
                else
                {
                    Assert.Fail("There were no rows in the posts table after Save method was called");
                }
            }
        }

        [TestMethod]
        public void GetAllPostsReturnsAllPosts()
        {
            InsertTestPosts(5);
            IList<Post> actualPosts = subject.GetAllPosts();
            Assert.AreEqual(5, actualPosts.Count);
        }

        [TestMethod]
        public void GetAllPostsReturnsPostData()
        {
            InsertTestPosts(1);
            IList<Post> actualPosts = subject.GetAllPosts();

            Assert.AreEqual(1, actualPosts.Count);
            Post actualPost = actualPosts.First();
            Assert.IsNotNull(actualPost);
            Assert.AreEqual("TEST BODY 1", actualPost.Body);
            Assert.AreEqual(new DateTime(2019, 10, 1), actualPost.Created);
            Assert.AreEqual("TEST NAME 1", actualPost.Name);
            Assert.AreEqual(true, actualPost.IsPublished);
        }

        private void InsertTestPosts(int numberOfPosts)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string insertStatements = string.Empty;
                for (int i = 1; i <= numberOfPosts; i++)
                {
                    insertStatements += $@"
                        INSERT INTO posts (body, name, created, published) 
                        VALUES ('TEST BODY {i}', 'TEST NAME {i}', '2019-10-{i}', {i % 2})";
                }

                SqlCommand command = connection.CreateCommand();
                command.CommandText = insertStatements;
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
