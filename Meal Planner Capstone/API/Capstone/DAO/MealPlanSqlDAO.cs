using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class MealPlanSqlDAO : IMealPlanDAO
    {
        private const string ADD_MEALPLAN = "INSERT INTO meal_plans (name, user_id, meal_indices) VALUES (@name,@userid,@indices); SELECT @@IDENTITY";
        private const string ADD_MEALS_TO_MEALPLAN = "INSERT INTO meal_plans_meals (meal_plan_id, meal_id) VALUES (@mealPlanId, @mealId)";
        private const string GET_MY_MEALPLANS = "Select * from meal_plans where user_id=@userid";
        private const string SELECT_MEALS_IN_MEALPLAN = "select meal_id from meal_plans_meals where meal_plan_id = @mealplanId";
        private const string SELECT_RECIPES_IN_MEAL = "select recipe_id from meals_recipes where meal_id = @mealId";
        private const string UPDATE_MEALPLAN = "UPDATE meal_plans SET name = @name, meal_indices = @indices where meal_plan_id = @mealPlanId";
        private const string DELETE_MEAL_FROM_MEALPLAN = "Delete from meal_plans_meals where meal_plan_id = @mealPlanId and meal_id = @mealId";
        private readonly string connectionString;

        public MealPlanSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public MealPlan AddMealPlan(MealPlan newMealPlan, int userId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(ADD_MEALPLAN, conn);
                    cmd.Parameters.AddWithValue("@name", newMealPlan.Name);
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@indices", newMealPlan.indices);
                    newMealPlan.MealPlanId = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch
            {

            }
            return newMealPlan;
        }

        public MealPlan AddMealstoMealPlan(MealPlan newMealPlan)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    conn.Open();
                    foreach (Meal meal in newMealPlan.MealList)
                    {
                        if (meal.MealId != 0)
                        {
                            SqlCommand cmd = new SqlCommand(ADD_MEALS_TO_MEALPLAN, conn);
                            cmd.Parameters.AddWithValue("@mealPlanId", newMealPlan.MealPlanId);
                            cmd.Parameters.AddWithValue("@mealId", meal.MealId);
                            cmd.ExecuteScalar();
                        }
                    }
                }
            }
            catch
            {

            }
            return newMealPlan;
        }

        public List<MealPlan> GetMyMealPlans(int userId)
        {
            List<MealPlan> myMealPlans = new List<MealPlan>();
            try
            {
                using (SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(GET_MY_MEALPLANS, conn);
                    cmd.Parameters.AddWithValue("@userid", userId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        MealPlan mealPlan = new MealPlan();
                        mealPlan.MealPlanId = Convert.ToInt32(reader["meal_plan_id"]);
                        mealPlan.Name = Convert.ToString(reader["name"]);
                        mealPlan.UserId = userId;
                        mealPlan.indices = Convert.ToString(reader["meal_indices"]);
                        myMealPlans.Add(mealPlan);

                    }
                }
            }
            catch
            {

            }
            return myMealPlans;
        }
        
        public List<MealPlan> GetMyMealList(List<MealPlan> myMealPlans, int userId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    conn.Open();

                    //LOOP THROUGH ALL MEALPLANS THIS USER HAS
                    foreach(MealPlan mealPlan in myMealPlans)
                    {
                        //initiate the meal list to go into this mealplan
                        mealPlan.MealList = new List<Meal>();

                        //get all the meal_ids of this specific mealplan
                        SqlCommand cmd = new SqlCommand(SELECT_MEALS_IN_MEALPLAN, conn);
                        cmd.Parameters.AddWithValue("@mealplanId", mealPlan.MealPlanId);
                        SqlDataReader rdr = cmd.ExecuteReader();

                        //indices is a string that holds a 0 where an empty meal is, or a 1 where an actual meal is
                        //loop through the indices and add a meal with its properties depending on if there is 
                        //information in that meal or if it is an empty meal
                        PopulateMealsIntoMealList(mealPlan, rdr);
                        rdr.Close();

                        //LOOP THROUGH ALL MEALS THIS MEALPLAN HAS
                        foreach (Meal meal in mealPlan.MealList)
                        {
                            //initiate the recipe list to go into this meal
                            meal.recipes = new List<Recipe>();

                            //get all the recipeIds of this specific meal
                            SqlCommand cmd2 = new SqlCommand(SELECT_RECIPES_IN_MEAL, conn);
                            cmd2.Parameters.AddWithValue("@mealId", meal.MealId);
                            SqlDataReader rdr2 = cmd2.ExecuteReader();
                            while (rdr2.Read())
                            {
                                Recipe recipe = new Recipe();
                                recipe.RecipeId = Convert.ToInt32(rdr2["recipe_id"]);
                                meal.recipes.Add(recipe);
                            }
                            rdr2.Close();

                            //get the rest of the recipe info (besides the ingredient list)
                            foreach (Recipe recipe in meal.recipes)
                            {
                                SqlCommand cmd3;
                                SqlDataReader rdr3;
                                SetRecipeDetails(conn, recipe, out cmd3, out rdr3);
                                rdr3.Close();
                                GetIngredientList(conn, recipe, out cmd3, out rdr3);
                            }
                        }

                    }

                }
            }
            catch
            {

            }
            return myMealPlans;
        }
        public MealPlan UpdateMealPlan(MealPlan mealplan)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(UPDATE_MEALPLAN, conn);
                    cmd.Parameters.AddWithValue("@mealPlanId", mealplan.MealPlanId);
                    cmd.Parameters.AddWithValue("@name", mealplan.Name);
                    cmd.Parameters.AddWithValue("@indices", mealplan.indices);
                    cmd.ExecuteNonQuery();
                }
            } 
            catch
            {

            }
            return mealplan;
        }

        public Meal AddMealToMealPlan(Meal meal, int mealPlanId)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(ADD_MEALS_TO_MEALPLAN, conn);
                    cmd.Parameters.AddWithValue("@mealPlanId", mealPlanId);
                    cmd.Parameters.AddWithValue("@mealId", meal.MealId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {

            }
            return meal;
        }

        public Meal DeleteMealFromMealPlan(Meal meal, int mealPlanId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(DELETE_MEAL_FROM_MEALPLAN, conn);
                    cmd.Parameters.AddWithValue("@mealPlanId", mealPlanId);
                    cmd.Parameters.AddWithValue("@mealId", meal.MealId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {

            }
            return meal;
        }


        //REFACTOR METHODS

        private static void SetRecipeDetails(SqlConnection conn, Recipe recipe, out SqlCommand cmd3, out SqlDataReader rdr3)
        {
            cmd3 = new SqlCommand("select * from recipes where recipe_id = @recipeId", conn);
            cmd3.Parameters.AddWithValue("@recipeId", recipe.RecipeId);
            rdr3 = cmd3.ExecuteReader();
            while (rdr3.Read())
            {
                recipe.RecipeName = Convert.ToString(rdr3["recipe_name"]);
                recipe.UserId = Convert.ToInt32(rdr3["user_id"]);
                recipe.Instructions = Convert.ToString(rdr3["instructions"]);
                recipe.Type = Convert.ToInt32(rdr3["type_id"]);
                recipe.Servings = Convert.ToInt32(rdr3["num_servings"]);
                recipe.IsShared = Convert.ToBoolean(rdr3["is_shared"]);
            }
        }

        private static void GetIngredientList(SqlConnection conn, Recipe recipe, out SqlCommand cmd3, out SqlDataReader rdr3)
        {
            //get the ingredient list for each recipe
            recipe.IngredientList = new List<RecipeIngredient>();
            cmd3 = new SqlCommand("select * from recipes_ingredients where recipe_id = @recipeId", conn);
            cmd3.Parameters.AddWithValue("@recipeId", recipe.RecipeId);
            rdr3 = cmd3.ExecuteReader();
            while (rdr3.Read())
            {
                RecipeIngredient r = new RecipeIngredient();
                r.IngredientId = Convert.ToInt32(rdr3["ingredient_id"]);
                r.Quantity = Convert.ToDecimal(rdr3["ingredient_qty"]);
                r.Unit = Convert.ToString(rdr3["ingredient_unit"]);
                r.RecipeId = Convert.ToInt32(rdr3["recipe_id"]);
                recipe.IngredientList.Add(r);
            }
            rdr3.Close();

            //get the ingredient name for each recipe ingredient
            foreach (RecipeIngredient ingredient in recipe.IngredientList)
            {
                cmd3 = new SqlCommand("select ingredient_name from ingredients where ingredient_id=@ingredientId", conn);
                cmd3.Parameters.AddWithValue("@ingredientId", ingredient.IngredientId);
                rdr3 = cmd3.ExecuteReader();
                while (rdr3.Read())
                {
                    ingredient.IngredientName = Convert.ToString(rdr3["ingredient_name"]);
                }
                rdr3.Close();
            }
        }

        private static void PopulateMealsIntoMealList(MealPlan mealPlan, SqlDataReader rdr)
        {
            List<int> indexList = new List<int>();
            //add meal id's from indices string into indexList
            string[] indexes = mealPlan.indices.Split(',');
            for (int j = 0; j < indexes.Length; j++)
            {
                if (indexes[j] != "0")
                {
                    if (rdr.Read())
                    {
                        indexList.Add(Convert.ToInt32(rdr["meal_id"]));
                    }
                }
                
            }

            //make meals and populate them into the mealList using the indexList
            for (int i = 0; i < indexes.Length; i++)
            {
                Meal meal = new Meal();
                for (int j = 0; j < indexList.Count; j++) 
                {
                    string index = indexes[i];
                    if (index == indexList[j].ToString())
                    {
                        meal.MealId = indexList[j];
                    }
                }
                mealPlan.MealList.Add(meal);
            }
        }

        
    }
}
