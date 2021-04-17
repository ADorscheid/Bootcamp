using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class RecipeIngredientSqlDAO : IRecipeIngredientDAO
    {
        private readonly string connectionString;
        private const string GET_INGREDIENTS_FOR_MY_RECIPE = "Select * from ingredients join recipes_ingredients on ingredients.ingredient_id = recipes_ingredients.ingredient_id join recipes on recipes_ingredients.recipe_id = recipes.recipe_id where recipes.recipe_id = @recipeId";
        private const string GET_INGREDIENTS_FOR_PUBLIC_RECIPE = "Select * from ingredients join recipes_ingredients on ingredients.ingredient_id = recipes_ingredients.ingredient_id join recipes on recipes_ingredients.recipe_id = recipes.recipe_id where recipes.recipe_id = @recipeId AND recipes.is_shared = 1";

        public RecipeIngredientSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }


        // Get ingredients for A Public Recipe
        public List<RecipeIngredient> GetPublicRecipeIngredients(int recipeId)
        {
            try
            {
                List<RecipeIngredient> listOfRecipeIngredients = new List<RecipeIngredient>();

                using (SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(GET_INGREDIENTS_FOR_PUBLIC_RECIPE, conn);
                    cmd.Parameters.AddWithValue("@recipeId", recipeId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        RecipeIngredient r = new RecipeIngredient();
                        r.IngredientId = Convert.ToInt32(reader["ingredient_id"]);
                        r.IngredientName = Convert.ToString(reader["ingredient_name"]);
                        r.Quantity = Convert.ToDecimal(reader["ingredient_qty"]);
                        r.Unit = Convert.ToString(reader["ingredient_unit"]);
                        r.RecipeId = Convert.ToInt32(reader["recipe_id"]);
                        r.UserId = Convert.ToInt32(reader["user_id"]);
                        listOfRecipeIngredients.Add(r);
                    }
                    return listOfRecipeIngredients;
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }


        // Get ingredients for My Recipe
        public List<RecipeIngredient> GetMyRecipeIngredients(int recipeId, int userId)
        {
            try
            {
                List<RecipeIngredient> listOfRecipeIngredients = new List<RecipeIngredient>();

                using (SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(GET_INGREDIENTS_FOR_MY_RECIPE, conn);
                    cmd.Parameters.AddWithValue("@recipeId", recipeId);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        RecipeIngredient r = new RecipeIngredient();
                        r.IngredientId = Convert.ToInt32(reader["ingredient_id"]);
                        r.IngredientName = Convert.ToString(reader["ingredient_name"]);
                        r.Quantity = Convert.ToDecimal(reader["ingredient_qty"]);
                        r.Unit = Convert.ToString(reader["ingredient_unit"]);
                        r.RecipeId = Convert.ToInt32(reader["recipe_id"]);
                        r.UserId = Convert.ToInt32(reader["user_id"]);

                        listOfRecipeIngredients.Add(r);
                    }
                    return listOfRecipeIngredients;
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public List<RecipeIngredient> AddIngredients(List<RecipeIngredient> ingredients, int recipeId)
        {
            try
            {
                List<RecipeIngredient> listOfRecipeIngredients = new List<RecipeIngredient>();

                using (SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    conn.Open();
                    foreach (RecipeIngredient ingredient in ingredients)
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO recipes_ingredients (recipe_id,ingredient_id,ingredient_qty,ingredient_unit) VALUES (@recipe_id, (select ingredient_id from ingredients where ingredient_name=@ingredient_name), @ingredient_qty, @ingredient_unit)", conn);
                        cmd.Parameters.AddWithValue("@recipe_id", recipeId);
                        cmd.Parameters.AddWithValue("@ingredient_name", ingredient.IngredientName);
                        cmd.Parameters.AddWithValue("@ingredient_qty", ingredient.Quantity);
                        cmd.Parameters.AddWithValue("@ingredient_unit", ingredient.Unit);
                        cmd.ExecuteScalar();
                    }
                }
            }
            catch
            {

            }
            return ingredients;
        }

        public RecipeIngredient AddIngredient(RecipeIngredient ingredient, int recipeId)
        {
            try
            {
                List<RecipeIngredient> listOfRecipeIngredients = new List<RecipeIngredient>();

                using (SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO recipes_ingredients (recipe_id,ingredient_id,ingredient_qty,ingredient_unit) VALUES (@recipe_id, (select ingredient_id from ingredients where ingredient_name=@ingredient_name), @ingredient_qty, @ingredient_unit)", conn);
                    cmd.Parameters.AddWithValue("@recipe_id", recipeId);
                    cmd.Parameters.AddWithValue("@ingredient_name", ingredient.IngredientName);
                    cmd.Parameters.AddWithValue("@ingredient_qty", ingredient.Quantity);
                    cmd.Parameters.AddWithValue("@ingredient_unit", ingredient.Unit);
                    cmd.ExecuteScalar();                
                }
            }
            catch
            {

            }
            return ingredient;
        }

        public RecipeIngredient UpdateQuantity(RecipeIngredient ingredient)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE recipes_ingredients SET ingredient_qty = @ingredient_qty where recipe_id = @recipe_id and ingredient_id = @ingredient_id", conn);
                    cmd.Parameters.AddWithValue("@recipe_id", ingredient.RecipeId);
                    cmd.Parameters.AddWithValue("@ingredient_id", ingredient.IngredientId);
                    cmd.Parameters.AddWithValue("@ingredient_qty", ingredient.Quantity);
                    cmd.ExecuteScalar();
                }
            }
            catch
            {

            }
            return ingredient;
        }

        public RecipeIngredient UpdateUnit(RecipeIngredient ingredient)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE recipes_ingredients SET ingredient_unit = @ingredient_unit where recipe_id = @recipe_id and ingredient_id = @ingredient_id", conn);
                    cmd.Parameters.AddWithValue("@recipe_id", ingredient.RecipeId);
                    cmd.Parameters.AddWithValue("@ingredient_id", ingredient.IngredientId);
                    cmd.Parameters.AddWithValue("@ingredient_unit", ingredient.Unit);
                    cmd.ExecuteScalar();
                }
            }
            catch
            {

            }
            return ingredient;
        }

        public RecipeIngredient DeleteIngredient(RecipeIngredient ingredient)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE from Recipes_Ingredients where recipe_id = @recipe_id and ingredient_id = @ingredient_id", conn);
                    cmd.Parameters.AddWithValue("@recipe_id", ingredient.RecipeId);
                    cmd.Parameters.AddWithValue("@ingredient_id", ingredient.IngredientId);
                    cmd.ExecuteScalar();
                }
            }
            catch
            {

            }
            return ingredient;
        }
    }
}
