using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class PantryIngredient
    {
        public User User { get; set; } //this is for the user ID, MAYBE CHANGE THIS TO AN INT USERID instead of an instance of user. SEE RECIPE CLASS

        public RecipeIngredient Ingredient { get; set; }

        public decimal Quantity { get; set; }

        public string Unit { get; set; }


        public PantryIngredient(User user, RecipeIngredient ingredient, decimal quantity, string unit)
        {
            this.User = user;
            this.Ingredient = ingredient;
            this.Quantity = quantity;
            this.Unit = unit;
        }
    }
}
