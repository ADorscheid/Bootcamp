using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using WorldDB.Models;

namespace WorldDB.DAL
{
    public class CountrySqlDAO : ICountryDAO
    {
        private const string SQL_GETCOUNTRYBYCODE = 
            @"Select * from Country Where Code = @countryCode;
            Select * from CountryLanguage cl Join Language l on cl.LanguageId = l.LanguageId 
                Where cl.CountryCode = @countryCode 
                Order by cl.Percentage DESC";

        private const string SQL_GETALLCOUNTRIES = "Select * from Country";
        private const string SQL_GETCOUNTRIESBYCONTINENT = "Select * from Country Where continent = @continent";
        private string connectionString;

        public CountrySqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Gets all countries in the World DB
        /// </summary>
        /// <returns></returns>
        public List<Country> GetCountries()
        {
            List<Country> countries = new List<Country>();

            try
            {
                using (SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    // Open the connection 
                    conn.Open();

                    // Create a command for Select
                    SqlCommand cmd = new SqlCommand(SQL_GETALLCOUNTRIES, conn);

                    // Execute the command and get a reader
                    SqlDataReader rdr = cmd.ExecuteReader();

                    // Loop through rows, create a Country object for each row, add it to the list
                    while (rdr.Read())
                    {
                        Country country = RowToObject(rdr);
                        countries.Add(country);
                    }

                    return countries;
                }
            }
            catch (SqlException ex)
            {
                // Log the error here

                throw;
            }
        }

        public List<Country> GetCountries(string continent)
        {
            List<Country> countries = new List<Country>();

            try
            {
                using (SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    // Open the connection 
                    conn.Open();

                    // Create a command for Select
                    SqlCommand cmd = new SqlCommand(SQL_GETCOUNTRIESBYCONTINENT, conn);
                    cmd.Parameters.AddWithValue("@continent", continent);

                    // Execute the command and get a reader
                    SqlDataReader rdr = cmd.ExecuteReader();

                    // Loop through rows, create a Country object for each row, add it to the list
                    while (rdr.Read())
                    {
                        Country country = RowToObject(rdr);
                        countries.Add(country);
                    }

                    return countries;
                }
            }
            catch (SqlException ex)
            {
                // Log the error here

                throw;
            }
        }

        public Country GetCountry(string code)
        {
            Country country = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    // Open the connection 
                    conn.Open();

                    // Create a command for Select
                    SqlCommand cmd = new SqlCommand(SQL_GETCOUNTRYBYCODE, conn);
                    cmd.Parameters.AddWithValue("@countryCode", code);

                    // Execute the command and get a reader
                    SqlDataReader rdr = cmd.ExecuteReader();

                    // See if there is a row returned, and if sdo, create a Country object for it
                    if (rdr.Read())
                    {
                        country = RowToObject(rdr);
                    }

                    // Now see if there is a second result set, and if so, process the CountryLanguage results

                    if (rdr.NextResult())
                    {
                        country.Languages = new List<CountryLanguage>();
                        while (rdr.Read())
                        {
                            country.Languages.Add(CountryLanguageSqlDAO.RowToObject(rdr));
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                // Log the error here

                throw;
            }
            return country;

        }

        private static Country RowToObject(SqlDataReader rdr)
        {
            Country country = new Country();
            country.Code = Convert.ToString(rdr["Code"]);
            country.Name = Convert.ToString(rdr["Name"]);
            country.Continent = Convert.ToString(rdr["Continent"]);
            country.Region = Convert.ToString(rdr["Region"]);
            country.SurfaceArea = Convert.ToDouble(rdr["SurfaceArea"]);
            country.Population = Convert.ToInt32(rdr["Population"]);

            if (rdr["IndepYear"] is DBNull)
            {
                country.IndepYear = null;
            }
            else
            {
                country.IndepYear = Convert.ToInt32(rdr["IndepYear"]);
            }
            return country;
        }
    }
}
