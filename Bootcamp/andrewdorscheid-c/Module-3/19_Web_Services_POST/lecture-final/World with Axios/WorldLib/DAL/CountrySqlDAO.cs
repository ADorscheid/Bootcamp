using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WorldLib.Models;

namespace WorldLib.DAL
{
    public class CountrySqlDAO : ICountryDAO
    {
        private readonly string connectionString;

        public CountrySqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Returns all of the cities.
        /// </summary>
        /// <returns></returns>
        public IList<Country> GetCountries()
        {
            List<Country> list = new List<Country>();

            try
            {
                // Create a new connection object
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    string sql = $"SELECT * FROM country order by name asc";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    // Execute the command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Loop through each row
                    while (reader.Read())
                    {
                        list.Add(RowToObject(reader));
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            return list;
        }

        public IList<Country> GetCountries(string continent)
        {
            continent = "%" + continent + "%";
            List<Country> list = new List<Country>();
            try
            {
                // Create a new connection object
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    string sql = $"SELECT * FROM country WHERE continent LIKE @continent Order By name";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@continent", continent);

                    // Execute the command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Loop through each row
                    while (reader.Read())
                    {
                        list.Add(RowToObject(reader));
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            return list;
        }

        /// <summary>
        /// Adds a country to the database.
        /// </summary>
        /// <param name="country">Country information to add</param>
        public int AddCountry(Country country)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"INSERT INTO country 
(code, name, continent, region, surfacearea, population, indepyear, capital) 
VALUES (@code, @name, @continent, @region, @surfacearea, @population, @indepyear, @capital)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@code", country.Code);
                    cmd.Parameters.AddWithValue("@name", country.Name);
                    cmd.Parameters.AddWithValue("@continent", country.Continent);
                    cmd.Parameters.AddWithValue("@region", country.Region);
                    cmd.Parameters.AddWithValue("@surfacearea", country.SurfaceArea);
                    cmd.Parameters.AddWithValue("@population", country.Population);
                    cmd.Parameters.AddWithValue("@indepyear", country.IndependenceYear);
                    cmd.Parameters.AddWithValue("@capital", country.CapitalId);

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        private Country RowToObject(SqlDataReader reader)
        {
            // Create a country
            Country obj = new Country();
            obj.Code = Convert.ToString(reader["Code"]);
            obj.Name = Convert.ToString(reader["Name"]);
            obj.Continent = Convert.ToString(reader["Continent"]);
            obj.Region = Convert.ToString(reader["Region"]);
            obj.SurfaceArea = Convert.ToInt32(reader["SurfaceArea"]);
            obj.Population = Convert.ToInt32(reader["Population"]);
            obj.IndependenceYear = (reader["indepyear"] is DBNull) ? null : (int?)Convert.ToInt32(reader["indepyear"]);
            obj.CapitalId = (reader["capital"] is DBNull) ? null : (int?)Convert.ToInt32(reader["capital"]);
            return obj;
    }

}
}
