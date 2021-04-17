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
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientDAO ingredientDAO;
        public IngredientController(IIngredientDAO ingredientDAO)
        {
            this.ingredientDAO = ingredientDAO;
        }
        [HttpGet]

        public ActionResult GetIngredients()
        {
            List<Ingredient> ingredients = ingredientDAO.GetAllIngredients();
            return Ok(ingredients);
        }

    }
}
