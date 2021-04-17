using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using WorldDB.Models;

namespace WorldDB.DAL
{
    public class CountryLanguageSqlDAO : ICountryLanguageDAO
    {
        private const string SQL_GETLANGUAGESBYCOUNTRY = 
@"Select * 
    from CountryLanguage cl 
    join Language l on cl.LanguageId = l.LanguageId 
    Where cl.CountryCode = @countryCode
    Order By cl.Percentage DESC";

        private string connectionString;
        public CountryLanguageSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<CountryLanguage> GetLanguages(string countryCode)
        {
            List<CountryLanguage> languages = new List<CountryLanguage>();
            try
            {
                // Create a db connection
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    // Create a command for the statement
                    SqlCommand cmd = new SqlCommand(SQL_GETLANGUAGESBYCOUNTRY, conn);
                    cmd.Parameters.AddWithValue("@countryCode", countryCode);

                    // Execute and get a data reader
                    SqlDataReader rdr = cmd.ExecuteReader();

                    // Loop through the result set and create City objects
                    while (rdr.Read())
                    {
                        CountryLanguage language = RowToObject(rdr);
                        languages.Add(language);
                    }

                }

            }
            catch
            {
                // Log this error 

                // Re-throw so it can be caught up the stack
                throw;
            }

            return languages;
        }

        static internal CountryLanguage RowToObject(SqlDataReader rdr)
        {
            return new CountryLanguage()
            {
                CountryCode = Convert.ToString(rdr["CountryCode"]),
                IsOfficial = Convert.ToBoolean(rdr["IsOfficial"]),
                LanguageId = Convert.ToInt32(rdr["LanguageId"]),
                LanguageName = Convert.ToString(rdr["LanguageName"]),
                Percentage = Convert.ToSingle(rdr["Percentage"])
            };
        }
    }
}
