using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using WorldDB.DAL;
using WorldDB.Models;
using WorldDB.Views;

namespace WorldDB
{
    class Program
    {
        static void Main(string[] args)
        {
            // This code reads the connection string from appsettings.json
            // Add the connection string to appsettings.json and un-comment the following lines to read the configuration
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            string connectionString = configuration.GetConnectionString("World");


            // TEMPORARY: DB EXAMPLE (vanilla, no DAO)
            //ReadCities();
            //return;

            ICountryDAO countryDAO = new CountrySqlDAO(connectionString);
            ICityDAO cityDAO = new CitySqlDAO(connectionString);

            // TODO 14a: Create a Model for CountryLanguage
            // TODO 14b: Create a CountryLanguageSqlDAO class (GetLanguages(string countryCode))
            // TODO 14c: Create an ICountryLanguageDAO interface
            ICountryLanguageDAO countryLanguageDAO = new CountryLanguageSqlDAO(connectionString);

            // Create a WorldDBMenu, passing in the country dao, and Run it
            WorldDBMenu menu = new WorldDBMenu(countryDAO, cityDAO, countryLanguageDAO);
            menu.Show();

            // Say goodbye to the user...
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("Goodbye...");
            Thread.Sleep(1500);
        }

        private static void ReadCities()
        {
            // Read cities from the database and list the results on the screen.
            // Add a parameter to the query to get the cities for a given country code.
            string connectionString = "Server=.\\SqlExpress;Database=World;Trusted_Connection=True;";

            Console.Write("Country Code: ");
            string countryCode = Console.ReadLine();

            try
            {
                // Create a connection
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // First open the connection
                    conn.Open();

                    // Now create a command for a sql statement
                    SqlCommand cmd = new SqlCommand("Select name, population from City Where CountryCode = @cc", conn);
                    cmd.Parameters.AddWithValue("@cc", countryCode);

                    // Execute the statement and get back a "reader"
                    SqlDataReader rdr = cmd.ExecuteReader();

                    // Loop through the results and display to the user
                    while (rdr.Read())
                    {
                        string name = Convert.ToString(rdr["Name"]);
                        int population = Convert.ToInt32(rdr["Population"]);
                        Console.WriteLine($"Name: {name}, Population: {population}");
                    }
                }
            }
            catch(SqlException ex)
            {
                Console.WriteLine($"There was a database error: {ex.Message}");
            }


            Console.ReadLine();
        }
    }
}
