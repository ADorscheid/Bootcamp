using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IRecipeDAO
    {
        List<Recipe> GetPublicRecipes();
        List<Recipe> GetPrivateRecipes(int userId);
        Recipe AddRecipe(Recipe recipe, int userId);
        Recipe UpdateRecipe(Recipe recipe);
    }
}