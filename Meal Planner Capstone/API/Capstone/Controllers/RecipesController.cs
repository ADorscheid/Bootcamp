using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class RecipesController : AuthorizedControllerBase  //ControllerBase
    {
        public readonly IRecipeDAO recipeDAO;
        public readonly IIngredientDAO ingredientDAO;
        public readonly IRecipeIngredientDAO recipeIngredientDAO;
        

        public RecipesController(IRecipeDAO recipedao, IIngredientDAO IngredientDAO, IRecipeIngredientDAO RecipeIngredientDAO)
        {
            this.recipeDAO = recipedao;
            this.ingredientDAO = IngredientDAO;
            this.recipeIngredientDAO = RecipeIngredientDAO;
        }

        [HttpGet]
        public ActionResult GetPublicRecipes()
        {
            List<Recipe> listOfRecipe = recipeDAO.GetPublicRecipes();
            return Ok(listOfRecipe);
        }

        
       [HttpGet("myrecipes")]
       [Authorize]
        public ActionResult GetPrivateRecipes()
        {
            List<Recipe> privateListOfRecipe = recipeDAO.GetPrivateRecipes(this.UserId);
            return Ok(privateListOfRecipe);
        }


        [HttpPost]
        [Authorize]
        public ActionResult AddRecipe(Recipe recipe)
        {
            // add new ingredients into the ingredient table
            if (recipe.NewIngredients.Count() > 0)
            {
                ingredientDAO.AddIngredients(recipe.NewIngredients);
            }

            // add recipe into recipes table
            recipe = recipeDAO.AddRecipe(recipe, this.UserId);

            // add recipe_id, ingredient_id, ingredient_qty, and ingredient_unit into recipes_ingredient table
            recipeIngredientDAO.AddIngredients(recipe.IngredientList, recipe.RecipeId);

            // return recipe so front end can use the recipe id
            // update recipe object so it has the ingredient id's in them?  front end doesn't need as of 4/7
            return Created($"/recipes/{recipe.RecipeId}",recipe);
        }

        [HttpPut]
        [Authorize]
        public ActionResult ModifyRecipe(Recipe editRecipe)
        {
            // get my original recipe with no updates
            List<Recipe> myRecipes = recipeDAO.GetPrivateRecipes(this.UserId);
            Recipe originalRecipe = new Recipe();
            foreach (Recipe recipe in myRecipes)
            {
                if (recipe.RecipeId == editRecipe.RecipeId)
                {
                    originalRecipe = recipe;
                }
            }
            originalRecipe.IngredientList = recipeIngredientDAO.GetMyRecipeIngredients(originalRecipe.RecipeId, this.UserId);

            //original ingredient Id's
            List<int> originalIngredientIds = new List<int>();
            foreach(RecipeIngredient ingredient in originalRecipe.IngredientList)
            {
                originalIngredientIds.Add(ingredient.IngredientId);
            }

            //update recipe details
            recipeDAO.UpdateRecipe(editRecipe);

            //add new ingredients into ingredients table
            if (editRecipe.NewIngredients.Count() > 0)
            {
                ingredientDAO.AddIngredients(editRecipe.NewIngredients);
            }

            //insert the new ingredients into recipes_ingredients
            foreach (RecipeIngredient eIngredient in editRecipe.IngredientList)
            {
                if (editRecipe.NewIngredients.Contains(eIngredient.IngredientName) || !originalIngredientIds.Contains(eIngredient.IngredientId))
                {
                    recipeIngredientDAO.AddIngredient(eIngredient, editRecipe.RecipeId);
                }          
            }

            //edit quantity, unit, or delete ingredients
            foreach (RecipeIngredient oIngredient in originalRecipe.IngredientList)
            {
                bool notFound = true;
                for (int i = 0; i < editRecipe.IngredientList.Count; i++)
                {                    
                    if (editRecipe.IngredientList[i].IngredientId == oIngredient.IngredientId)
                    {
                        notFound = false;
                        if (editRecipe.IngredientList[i].Quantity != oIngredient.Quantity)
                        {
                            //update quantity
                            recipeIngredientDAO.UpdateQuantity(editRecipe.IngredientList[i]);
                        }
                        if (editRecipe.IngredientList[i].Unit != oIngredient.Unit)
                        {
                            //update unit
                            recipeIngredientDAO.UpdateUnit(editRecipe.IngredientList[i]);
                        }
                    }
                    if (i == editRecipe.IngredientList.Count - 1 && notFound)
                    {
                        // delete the ingredient
                        recipeIngredientDAO.DeleteIngredient(oIngredient);
                    }                   
                }          
            }

            return Ok(editRecipe);
        }

   }
}
