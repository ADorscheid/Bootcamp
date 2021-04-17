using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Communities.Tests
{
    [TestClass]
    public class CommunitySqlDaoTests : DaoIntegrationTest
    {
        private CommunitySqlDao subject;

        [TestInitialize]
        public override void SetUp()
        {
            base.SetUp();
            subject = new CommunitySqlDao(ConnectionString);
        }

        [TestMethod]
        public void SaveAddsARow()
        {
            Community newCommunity = new Community
            {
                Created = new DateTime(2019, 10, 20),
                IsLive = true,
                Latitude = 40.7253251m,
                Longitude = -83.4638393m,
                Name = "TEST name"
            };

            subject.Save(newCommunity);

            Assert.AreEqual(1, GetRowCount("communities"));
        }

        [TestMethod]
        public void SaveAddsAllCommunityData()
        {
            Community newCommunity = new Community
            {
                Created = new DateTime(2019, 10, 20),
                IsLive = true,
                Latitude = 40.725325m,
                Longitude = -83.463839m,
                Name = "TEST name"
            };

            subject.Save(newCommunity);

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"
                    SELECT id, name, latitude, longitude, created, live
                    FROM communities
                    WHERE id = (SELECT MAX(id) FROM communities)";

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Assert.AreEqual(newCommunity.Created, (DateTime)reader["created"]);
                    Assert.AreEqual(newCommunity.Id, (int)reader["id"]);
                    Assert.IsTrue((bool)reader["live"]);
                    Assert.AreEqual(newCommunity.Latitude, (decimal)reader["latitude"]);
                    Assert.AreEqual(newCommunity.Longitude, (decimal)reader["longitude"]);
                    Assert.AreEqual(newCommunity.Name, reader["name"] as string);
                }
                else
                {
                    Assert.Fail("There were no rows in the communities table after Save method was called");
                }
            }
        }

        [TestMethod]
        public void GetAllCommunitiesReturnsAllCommunities()
        {
            InsertTestCommunities(5);
            IList<Community> actualCommunities = subject.GetAllCommunities();
            Assert.AreEqual(5, actualCommunities.Count);
        }

        [TestMethod]
        public void GetAllCommunitiesReturnsCommunityData()
        {
            InsertTestCommunities(1);
            IList<Community> actualCommunities = subject.GetAllCommunities();

            Assert.AreEqual(1, actualCommunities.Count);
            Community actualCommunity = actualCommunities.First();
            Assert.IsNotNull(actualCommunity);
            Assert.AreEqual(new DateTime(2019, 10, 1), actualCommunity.Created);
            Assert.AreEqual(true, actualCommunity.IsLive);
            Assert.AreEqual(40.725325m, actualCommunity.Latitude);
            Assert.AreEqual(-83.463839m, actualCommunity.Longitude);
            Assert.AreEqual("TEST name 1", actualCommunity.Name);
        }

        private void InsertTestCommunities(int numberOfCommunities)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string insertStatements = string.Empty;
                for (int i = 1; i <= numberOfCommunities; i++)
                {
                    insertStatements += $@"
                        INSERT INTO communities (name, latitude, longitude, created, live)
                        VALUES ('TEST name {i}', 40.725325, -83.463839, '2019-10-{i}', {i % 2})";
                }

                SqlCommand command = connection.CreateCommand();
                command.CommandText = insertStatements;

                connection.Open();

                command.ExecuteNonQuery();
            }
        }
    }
}
