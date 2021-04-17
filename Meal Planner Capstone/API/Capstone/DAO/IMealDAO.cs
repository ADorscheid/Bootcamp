using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public interface IMealDAO
    {
        List<Meal> GetMyMeals(int userid);
        List<Meal> AddMeals(List<Meal> newMeals, int userid);
    }
}
