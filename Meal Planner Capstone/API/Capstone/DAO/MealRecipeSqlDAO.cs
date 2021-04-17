using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class MealRecipeSqlDAO: IMealRecipeDAO
    {
        private const string ADD_MEAL_RECIPES = "INSERT INTO meals_recipes (meal_id, recipe_id) VALUES (@mealId, @recipeId)";
        private readonly string connectionString;

        public MealRecipeSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public List<Meal> AddMealRecipes(List<Meal> mealsToAdd)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    conn.Open();
                    foreach(Meal meal in mealsToAdd)
                    {
                        for (int i = 0; i < meal.recipes.Count(); i++)
                        {
                            SqlCommand cmd = new SqlCommand(ADD_MEAL_RECIPES, conn);
                            cmd.Parameters.AddWithValue("@mealId", meal.MealId);
                            cmd.Parameters.AddWithValue("@recipeId", meal.recipes[i].RecipeId);
                            cmd.ExecuteScalar();
                        }
                    }
                }
            }
            catch
            {

            }
            return mealsToAdd;
        }
    }
}
