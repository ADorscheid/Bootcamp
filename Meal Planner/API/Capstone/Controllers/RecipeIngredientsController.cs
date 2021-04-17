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
    public class RecipeIngredientsController : AuthorizedControllerBase
    {
        private readonly IRecipeIngredientDAO recipeIngredientsDAO;
        private readonly IRecipeDAO recipeDAO;

        public RecipeIngredientsController(IRecipeIngredientDAO recipeIngredientsDAO, IRecipeDAO recipeDAO)
        {
            this.recipeIngredientsDAO = recipeIngredientsDAO;
            this.recipeDAO = recipeDAO;
        }

        [HttpGet("{recipeId}")]
        public ActionResult GetRecipe(int recipeId)
        {
            // call recipeDAO to get list of recipes, get recipe, then check parameters

            List<Recipe> privateListOfRecipe = recipeDAO.GetPrivateRecipes(this.UserId);

            List<RecipeIngredient> listOfRecipeIngredients = new List<RecipeIngredient>();

            List<Recipe> publicListOfRecipe = recipeDAO.GetPublicRecipes();


            foreach (Recipe recipe in privateListOfRecipe)
            {
                if (recipe.UserId == this.UserId && recipe.RecipeId == recipeId)
                {
                    listOfRecipeIngredients = recipeIngredientsDAO.GetMyRecipeIngredients(recipe.RecipeId, this.UserId);
                    return Ok(listOfRecipeIngredients);
                }
            }

            foreach(Recipe recipe in publicListOfRecipe)
            {
                if(recipe.RecipeId == recipeId && recipe.IsShared == true)
                {
                    listOfRecipeIngredients = recipeIngredientsDAO.GetPublicRecipeIngredients(recipeId);
                    return Ok(listOfRecipeIngredients);
                }
            }
            return Forbid();
          

           

            //if (recipe.IsShared)
            //{
            //    List<RecipeIngredient> listOfRecipeIngredients = recipeIngredientsDAO.GetPublicRecipeIngredients(recipe.RecipeId);
            //    return Ok(listOfRecipeIngredients);
            //}
            //else if (recipe.UserId == this.UserId)
            //{
            //    List<RecipeIngredient> listOfRecipeIngredients = recipeIngredientsDAO.GetMyRecipeIngredients(recipe.RecipeId, this.UserId);
            //    return Ok(listOfRecipeIngredients);
            //}
            //return Forbid();
        }
    }
}
