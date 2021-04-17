using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public interface IMealPlanDAO
    {
        MealPlan AddMealPlan(MealPlan newMealPlan, int userId);
        MealPlan AddMealstoMealPlan(MealPlan newMealPlan);
        List<MealPlan> GetMyMealPlans(int userId);
        List<MealPlan> GetMyMealList(List<MealPlan> myMealPlans, int userId);
        MealPlan UpdateMealPlan(MealPlan mealplan);
        Meal AddMealToMealPlan(Meal meal, int mealPlanId);
        Meal DeleteMealFromMealPlan(Meal meal, int mealPlanId);
    }
}
