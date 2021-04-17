using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class MealPlan
    {
        public int MealPlanId { get; set; }

        public string Name { get; set; }
        public int UserId { get; set; }
        public List<Meal> MealList { get; set; }
        public string indices { get; set; }

        public MealPlan()
        {
        }


        // maybe need a time_priod property, can update later if need be.
    }
}
