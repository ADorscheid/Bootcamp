using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading;
using WorldDB.DAL;
using WorldDB.Views;

namespace WorldDB
{
    class Program
    {
        static void Main(string[] args)
        {
            // This code reads the connection string from appsettings.json
            // TODO 03: Add the connection string to appsettings.json and un-comment the following lines to read the configuration
            //IConfigurationBuilder builder = new ConfigurationBuilder();
            //builder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            //            IConfigurationRoot configuration = builder.Build();
            //string connectionString = configuration.GetConnectionString("World");


            // TEMPORARY: DB EXAMPLE (vanilla, no DAO)
            ReadCities();
            return;

            // TODO 04a: Create a Model for Country to go with the City model we already have
            // TODO 04b: Create a CountrySqlDAO class (GetCountries, GetCountries(continent), GetCountry(code))
            // TODO 04c: Create an ICountryDAO interface


            // TODO 10: Create a CitySqlDAO class (GetCitiesByCountryCode)
            // TODO 10a: Create an ICityDAO interface

            // TODO 14a: Create a Model for CountryLanguage
            // TODO 14b: Create a CountryLanguageSqlDAO class (GetLanguages(string countryCode))
            // TODO 14c: Create an ICountryLanguageDAO interface


            // TODO 05b: Create a WorldDBMenu, passing in the country dao, and Run it
            WorldDBMenu menu = new WorldDBMenu();
            menu.Show();

            // Say goodbye to the user...
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("Goodbye...");
            Thread.Sleep(1500);
        }

        private static void ReadCities()
        {
            // TODO 01: Read cities from the database and list the results on the screen.

            // TODO 02: Add a parameter to the query to get the cities for a given country code.

            Console.ReadLine();
        }
    }
}
