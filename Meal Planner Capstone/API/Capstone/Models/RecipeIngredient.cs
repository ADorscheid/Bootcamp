using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class RecipeIngredient
    {
        public int IngredientId { get; set; }
        public string IngredientName { get; set; }
        public decimal Quantity { get; set; }
        public string Unit { get; set; }
        public int RecipeId { get; set; }
        public int UserId { get; set; }


        public RecipeIngredient(int ingredientId, string ingredient_name, decimal quantity, string unit, int recipeId, int userId)
        {
            this.IngredientId = ingredientId;
            this.IngredientName = ingredient_name;
            this.Quantity = quantity;
            this.Unit = unit;
            this.RecipeId = recipeId;
            this.UserId = userId;
        }
        public RecipeIngredient()
        {

        }
    }
}
