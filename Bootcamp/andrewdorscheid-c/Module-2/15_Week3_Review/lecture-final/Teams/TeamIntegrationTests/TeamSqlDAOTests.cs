using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.SqlClient;
using System.IO;
using Teams.DAL;
using Teams.Models;

namespace TeamIntegrationTests
{
    [TestClass]
    public class TeamSqlDAOTests
    {
        private string connectionString = @"Server=.\SQLExpress;Database=NFLDB;Trusted_Connection=True;";
        private TeamSqlDAO teamDAO;
        private int BrownsTeamId = 0;

        [TestInitialize]
        public void SetupBeforeEachTest()
        {
            // Read the Test-setup script into a string
            string setupScript = File.ReadAllText("SetupTestData.SQL");

            // Create a connection
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(setupScript, conn);
                SqlDataReader rdr =  cmd.ExecuteReader();

                if (rdr.Read())
                {
                    BrownsTeamId = Convert.ToInt32(rdr["BrownsId"]);
                }
            }

            // Execute the test setup script

            // Create a dao to be used in all the tests.
            this.teamDAO = new TeamSqlDAO(connectionString);
        }

        [TestMethod]
        public void GetByIdWithBadId_ShouldReturnNULL()
        {
            // Arrange - Create an instance of the DAO

            // TODO: LATER: Run the TestSetup script

            // Act - Execute the GetById method with a known bad id
            Team actualTeam = teamDAO.GetTeamById(-1);

            // Assert
            Assert.IsNull(actualTeam);
        }

        [TestMethod]
        public void GetByIdWithGoodId_ShouldReturnATeam()
        {
            // Arrange - Create an instance of the DAO

            // TODO: LATER: Run the TestSetup script

            // Act - Execute the GetById method with a known bad id
            Team actualTeam = teamDAO.GetTeamById(this.BrownsTeamId);

            // Assert
            Assert.IsNotNull(actualTeam);
            Assert.AreEqual("Cleveland", actualTeam.Location);
            Assert.AreEqual("Browns", actualTeam.TeamName);

        }
    }
}
