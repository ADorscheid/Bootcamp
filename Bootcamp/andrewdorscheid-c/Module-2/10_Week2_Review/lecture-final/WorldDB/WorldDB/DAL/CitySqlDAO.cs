using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using WorldDB.Models;

namespace WorldDB.DAL
{
    public class CitySqlDAO : ICityDAO
    {
        private const string SQL_GETCITIESBYCOUNTRY = "Select * from City where CountryCode = @countryCode";
        private const string SQL_INSERTCITY = "Insert into City (Name, District, CountryCode, Population) Values (@name, @district, @countryCode, @population); Select @@IDENTITY;";
        private string connectionString;

        public CitySqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Get all the cities for a given country
        /// </summary>
        /// <param name="countryCode">ISO Code for the country</param>
        /// <returns>List of City objects for that country</returns>
        public List<City> GetCitiesByCountry(string countryCode)
        {
            List<City> cities = new List<City>();
            try
            {
                // Create a db connection
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    // Create a command for the statement
                    SqlCommand cmd = new SqlCommand(SQL_GETCITIESBYCOUNTRY, conn);
                    cmd.Parameters.AddWithValue("@countryCode", countryCode);

                    // Execute and get a data reader
                    SqlDataReader rdr = cmd.ExecuteReader();

                    // Loop through the result set and create City objects
                    while (rdr.Read())
                    {
                        City city = RowToObject(rdr);
                        cities.Add(city);
                    }

                }

            }
            catch
            {
                // Log this error 

                // Re-throw so it can be caught up the stack
                throw;
            }

            return cities;
        }

        /// <summary>
        /// Adds a city to the db
        /// </summary>
        /// <param name="cityToAdd">A City object with values in its properties for the new city</param>
        /// <returns>The id of the added city.</returns>
        public int AddCity(City cityToAdd)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    // Create the command to insert
                    SqlCommand cmd = new SqlCommand(SQL_INSERTCITY, conn);
                    cmd.Parameters.AddWithValue("@name", cityToAdd.Name);
                    cmd.Parameters.AddWithValue("@district", cityToAdd.District);
                    cmd.Parameters.AddWithValue("@countryCode", cityToAdd.CountryCode);
                    cmd.Parameters.AddWithValue("@population", cityToAdd.Population);

                    int newId = Convert.ToInt32(cmd.ExecuteScalar());
                    return newId;
                }
            }
            catch (SqlException ex)
            {
                // Log it!

                throw;
            }
        }

        public int DeleteCity(string cityName, string countryCode)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("Delete From City Where Name = @name and CountryCode = @countryCode", conn);
                cmd.Parameters.AddWithValue("@name", cityName);
                cmd.Parameters.AddWithValue("@countryCode", countryCode);

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected;
            }
        }

        private static City RowToObject(SqlDataReader rdr)
        {
            return new City()
            {
                CityId = Convert.ToInt32(rdr["CityId"]),
                CountryCode = Convert.ToString(rdr["CountryCode"]),
                District = Convert.ToString(rdr["District"]),
                Name = Convert.ToString(rdr["Name"]),
                Population = Convert.ToInt32(rdr["Population"])
            };
        }
    }
}
