using System.Collections.Generic;

namespace Capstone.Models
{
    public class Recipe
    {
        public int RecipeId { get; set;  }

        public string RecipeName { get; set; }

        public int UserId { get; set; } // user id, Debated on having an int for userID or an instance of User for our userId.  
        public string Instructions { get; set; }
        public int Type { get; set; }

        public int Servings { get; set; }

        public bool IsShared { get; set; }
        public List<RecipeIngredient> IngredientList { get; set; }
        public List<string> NewIngredients { get; set; }
        public int CookTime { get; set; }

        public string ImgUrl { get; set; }

        public Recipe(int recipeId, string recipeName, int userId, string instructions, int type, int servings, bool isshared, List<RecipeIngredient> ingredientList, List<string> newIngredients)
        {
            this.RecipeId = recipeId;
            this.RecipeName = recipeName;
            this.UserId = userId;
            this.Instructions = instructions;
            this.Type = type;
            this.Servings = servings;
            this.IsShared = isshared;
            this.IngredientList = ingredientList;
            this.NewIngredients = newIngredients;
           
        }
        public Recipe()
        {

        }

    }






}
