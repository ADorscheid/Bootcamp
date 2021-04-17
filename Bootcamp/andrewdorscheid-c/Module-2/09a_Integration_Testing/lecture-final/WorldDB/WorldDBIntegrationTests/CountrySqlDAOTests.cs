using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using WorldDB.DAL;
using WorldDB.Models;

namespace WorldDBIntegrationTests
{
    [TestClass]
    public class CountrySqlDAOTests
    {
        const string connectionString = "Server=.\\SQLExpress;Database=World_Test;Trusted_Connection=True;";
        private CountrySqlDAO dao;

        [TestInitialize]
        public void Arrange_For_Each_Test()
        {
            // Establish the "known state" of the database
            SetupDB();

            // Create an instance of CountrySqlDAO
            this.dao = new CountrySqlDAO(connectionString);

        }

        [TestMethod]
        public void GetCountryByIdTest()
        {
            // Arrange


            // Act
            // Call the GetCountry method
            Country country = dao.GetCountry("USA");

            //Assert
            // Make sure we get back the country we expect
            Assert.IsNotNull(country);
            Assert.AreEqual("United States", country.Name);


        }

        [TestMethod]
        public void GetCountriesByContinentTest()
        {
            // Arrange


            // Act
            // Call the GetCountries method
            List<Country> countries = dao.GetCountries("North America");

            //Assert
            // Make sure we get back the country we expect
            Assert.IsNotNull(countries);
            Assert.AreEqual(2, countries.Count);
        }

        private void SetupDB()
        {
            // Read the DB setup script from the text file
            string path = "DBSetup.sql";
            string setupScript = File.ReadAllText(path);

            // Create a new connection 
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Create a new Command from the text file and execute it
                SqlCommand cmd = new SqlCommand(setupScript, conn);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
