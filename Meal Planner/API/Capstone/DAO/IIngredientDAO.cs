using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IIngredientDAO
    {
        List<Ingredient> GetAllIngredients();
        List<string> AddIngredients(List<string> newIngredients);
    }
}