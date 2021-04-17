using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WorldLib.Models;

namespace WorldLib.DAL
{
    public class CitySqlDAO : ICityDAO
    {
        private readonly string connectionString;

        public CitySqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public City GetCityById(int id)
        {
            City city = null;
            try
            {
                // Create a new connection object
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    string sql =
@"SELECT city.*, ctry.name countryName 
FROM city 
join country ctry on city.countrycode = ctry.code
where id = @id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    // Execute the command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Loop through each row
                    if (reader.Read())
                    {
                        // Create a city
                        city = RowToObject(reader);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return city;
        }

        /// <summary>
        /// Returns all of the cities.
        /// </summary>
        /// <returns></returns>
        public IList<City> GetCities()
        {
            List<City> output = new List<City>();

            try
            {
                // Create a new connection object
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    string sql = 
@"SELECT city.*, ctry.name countryName FROM city
join country ctry on city.countrycode = ctry.code
order by countryName, district, name";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    // Execute the command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Loop through each row
                    while (reader.Read())
                    {
                        City city = RowToObject(reader);
                        output.Add(city);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return output;
        }

        public IList<City> GetCities(string countryCode, string district)
        {
            district = "%" + district + "%";

            List<City> output = new List<City>();

            try
            {
                // Create a new connection object
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();
                 
                    string sql =
@"SELECT city.*, ctry.name countryName FROM city
join country ctry on city.countrycode = ctry.code
WHERE countryCode = @countryCode AND district LIKE @district
order by countryName, district, name";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@countryCode", countryCode);
                    cmd.Parameters.AddWithValue("@district", district);

                    // Execute the command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Loop through each row
                    while (reader.Read())
                    {
                        City city = RowToObject(reader);
                        output.Add(city);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return output;
        }

        private City RowToObject(SqlDataReader reader)
        {
            // Create a city
            City city = new City();
            city.CityId = Convert.ToInt32(reader["id"]);
            city.Name = Convert.ToString(reader["name"]);
            city.CountryCode = Convert.ToString(reader["countrycode"]);
            city.CountryName = Convert.ToString(reader["countryname"]);
            city.District = Convert.ToString(reader["district"]);
            city.Population = Convert.ToInt32(reader["population"]);
            return city;
        }

        /// <summary>
        /// Adds a city to the database.
        /// </summary>
        /// <param name="city"></param>
        public int AddCity(City city)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = $"INSERT INTO city (name, countryCode, district, population) VALUES (@name, @countryCode, @district, @population); Select @@Identity;";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@name", city.Name);
                    cmd.Parameters.AddWithValue("@countryCode", city.CountryCode);
                    cmd.Parameters.AddWithValue("@district", city.District);
                    cmd.Parameters.AddWithValue("@population", city.Population);

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public void UpdateCity(City city)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = $"Update city Set name = @name, countrycode = @countryCode, district = @district, population = @population where id = @id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", city.CityId);
                    cmd.Parameters.AddWithValue("@name", city.Name);
                    cmd.Parameters.AddWithValue("@countryCode", city.CountryCode);
                    cmd.Parameters.AddWithValue("@district", city.District);
                    cmd.Parameters.AddWithValue("@population", city.Population);

                    int i = cmd.ExecuteNonQuery();
                    return;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public void DeleteCity(int cityId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = $"Delete from city where id = @id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", cityId);

                    cmd.ExecuteNonQuery();
                    return;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
