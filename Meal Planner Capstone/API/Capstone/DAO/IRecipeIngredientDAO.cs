using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IRecipeIngredientDAO
    {
        List<RecipeIngredient> GetMyRecipeIngredients(int recipeId, int userId);
        List<RecipeIngredient> GetPublicRecipeIngredients(int recipeId);
        List<RecipeIngredient> AddIngredients(List<RecipeIngredient> ingredients, int recipeId);
        RecipeIngredient AddIngredient(RecipeIngredient ingredient, int recipeId);
        RecipeIngredient DeleteIngredient(RecipeIngredient ingredient);
        RecipeIngredient UpdateUnit(RecipeIngredient ingredient);
        RecipeIngredient UpdateQuantity(RecipeIngredient ingredient);

    }
}