using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MealsController : AuthorizedControllerBase
    {
        public readonly IRecipeDAO recipeDAO;
        public readonly IMealDAO mealDAO;

        public MealsController(IRecipeDAO recipedao, IMealDAO mealdao)
        {
            this.recipeDAO = recipedao;
            this.mealDAO = mealdao;
        }

        [HttpGet]

        public ActionResult GetMyMeals()
        {
            List<Meal> myMeals = mealDAO.GetMyMeals(this.UserId);
            return Ok(myMeals);
            
        }


    }
}
