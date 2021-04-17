using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class MealSqlDAO: IMealDAO
    {
        private const string GET_MEALS = "Select * from meals where user_id = @userid";
        private const string ADD_MEALS = "INSERT INTO meals (meal_name, user_id) VALUES (@mealname, @userid); Select @@IDENTITY";
        private readonly string connectionString;

        public MealSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public List<Meal> GetMyMeals(int userid)
        {
            List<Meal> meals = new List<Meal>();
            try
            {
                using (SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(GET_MEALS, conn);
                    cmd.Parameters.AddWithValue("@userid", userid);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Meal meal = new Meal();
                        meal.MealId = Convert.ToInt32(reader["meal_id"]);
                        meal.MealName = Convert.ToString(reader["meal_name"]);
                        meal.UserId = userid;
                        //meal.TimeOfDay = Convert.ToInt32(reader["time_of_day_id"]);
                        meals.Add(meal);

                    }

                }
            } 
            catch
            {

            }
            return meals;

        }

        public List<Meal> AddMeals(List<Meal> newMeals, int userid)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    conn.Open();              
                    
                    foreach (Meal meal in newMeals)
                    {
                        SqlCommand cmd = new SqlCommand(ADD_MEALS, conn);
                        cmd.Parameters.AddWithValue("@userid", userid);
                        if (meal.MealName == null)
                        {
                            meal.MealName = "";
                        }
                        cmd.Parameters.AddWithValue("@mealname", meal.MealName);
                        meal.MealId = Convert.ToInt32(cmd.ExecuteScalar());
                    }                    
                }
            }
            catch
            {

            }
            return newMeals;
        }

    }
}
