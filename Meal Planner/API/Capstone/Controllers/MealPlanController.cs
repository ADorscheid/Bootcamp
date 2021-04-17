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
    [Route("[controller]")]
    [ApiController]
    public class MealPlanController : AuthorizedControllerBase
    {
        //meal dao and meal plan dao

        public readonly IMealPlanDAO mealPlanDAO;
        public readonly IMealDAO mealDAO;
        public readonly IMealRecipeDAO mealRecipeDAO;

        public MealPlanController(IMealPlanDAO mealplandao, IMealDAO mealdao, IMealRecipeDAO MealRecipeDAO)
        {
            this.mealPlanDAO = mealplandao;
            this.mealDAO = mealdao;
            this.mealRecipeDAO = MealRecipeDAO;
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddMealPlan(MealPlan mealPlan)
        {
            //gets all the meals that we need to add into the database
            //link mealid's with their respecitve recipeid's 
            
            List<Meal> newMeals = UpdateNewMealsIntoDatabase(mealPlan);
            mealPlan = SetIndices(mealPlan);
            //post mealPlan to mealPlans to meal_plans table
            mealPlanDAO.AddMealPlan(mealPlan, this.UserId);

            //post mealPlan and meals to meal_plans_meals table
            mealPlanDAO.AddMealstoMealPlan(mealPlan);

            //return mealPlan with all new mealPlan id's (only meals with recipes in it got an id)
            mealPlan.UserId = this.UserId;
            return Created($"/mealplan/{mealPlan.MealPlanId}", mealPlan);
            //meallist[1,2,1,3,1,4,1]

        }



        [HttpGet]
        public ActionResult GetMyMealPlans()
        {
            List<MealPlan> myMealPlans = mealPlanDAO.GetMyMealPlans(this.UserId);
            List<MealPlan> myMealPlansWithMeals = mealPlanDAO.GetMyMealList(myMealPlans, this.UserId);
            return Ok(myMealPlans);
        }

        [HttpPut]
        [Authorize]
        public ActionResult UpdateMealPlan(MealPlan mealplan)
        {
            List<MealPlan> myMealPlans = mealPlanDAO.GetMyMealPlans(this.UserId);
            List<MealPlan> myMealPlansWithMeals = mealPlanDAO.GetMyMealList(myMealPlans, this.UserId);
            MealPlan originalMealPlan = new MealPlan();
            foreach (MealPlan mealPlan in myMealPlans)
            {
                if (mealPlan.MealPlanId == mealplan.MealPlanId)
                {
                    originalMealPlan = mealPlan; // meal plan with no edits
                }
            }
            if (mealplan.UserId == this.UserId)
            {
                
                List<Meal> newMeals = UpdateNewMealsIntoDatabase(mealplan);
                mealplan = SetIndices(mealplan);
                //link mealid's with their respecitve recipeid's 
                mealPlanDAO.UpdateMealPlan(mealplan);

                for (int i = 0; i < mealplan.MealList.Count; i++)
                {
                    if (mealplan.MealList[i].MealId != originalMealPlan.MealList[i].MealId)
                    {
                        //if only they added meals insert another meal into that meal plan
                        if(originalMealPlan.MealList[i].MealId == 0)
                        {
                            // insert meal
                            mealPlanDAO.AddMealToMealPlan(mealplan.MealList[i], mealplan.MealPlanId);
                        }
                        else if (mealplan.MealList[i].MealId == 0)
                        {
                            // delete meal
                            mealPlanDAO.DeleteMealFromMealPlan(originalMealPlan.MealList[i], mealplan.MealPlanId);

                        } 
                        else
                        {
                            //delete original meal
                            mealPlanDAO.DeleteMealFromMealPlan(originalMealPlan.MealList[i], mealplan.MealPlanId);
                            //Add new meal 
                            mealPlanDAO.AddMealToMealPlan(mealplan.MealList[i], mealplan.MealPlanId);
                        }                       

                    }
                }
                return Ok(mealplan);
            }
            return Forbid();
        }

        //Methods 
        private MealPlan SetIndices(MealPlan mealplan)
        {
            mealplan.indices = "";
            for (int i = 0; i < mealplan.MealList.Count; i++)
            {
                if (mealplan.MealList[i].recipes.Count > 0)
                {
                    string id = mealplan.MealList[i].MealId.ToString();
                    mealplan.indices += id;
                }
                else
                {
                    mealplan.indices += '0';
                }
                if (i < mealplan.MealList.Count - 1)
                {
                    mealplan.indices += ',';
                }
            }
            return mealplan;
        }

        private List<Meal> UpdateNewMealsIntoDatabase(MealPlan mealPlan)
        {
            // get all meals of the logged in user from the database
            List<Meal> myMeals = mealDAO.GetMyMeals(this.UserId);

            //get all id's from those meals
            List<int> mealIds = new List<int>();
            foreach (Meal meal in myMeals)
            {
                mealIds.Add(meal.MealId);
            }

            //loop through mealplan's meal list and find meals not in the database
            List<Meal> newMeals = new List<Meal>();
            foreach (Meal meal in mealPlan.MealList) //loops through 7 times everytime
            {

                if (!mealIds.Contains(meal.MealId))
                {
                    if (meal.recipes.Count() != 0 && meal.recipes[0].RecipeId!=0)
                    {
                        newMeals.Add(meal);
                    }
                }
            }
            //add meals that are not in the database
            if (newMeals.Count > 0)
            {
                mealDAO.AddMeals(newMeals, this.UserId);
                mealRecipeDAO.AddMealRecipes(newMeals);
            }

            return newMeals;
        }
    }
}
