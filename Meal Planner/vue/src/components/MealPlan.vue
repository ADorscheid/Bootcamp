<template>
  <div class="entirePage">
    <h2>
      Current Meal Plan
      <span
        @click="
          visualParams.viewMode = true;
          visualParams.addMeal = false;
        "
        v-show="!visualParams.viewMode"
        >👁</span
      ><span
        @click="visualParams.viewMode = false"
        v-show="visualParams.viewMode"
        >🖉</span
      >
    </h2>
    <!-- Dropdown to select meal plans -->
    <div>
      <label for="Saved Meal Plans">Saved Meal Plans: </label>
      <select
        v-model="visualParams.selectedText"
        @change="showSavedMealPlan()"
        name="Saved Meal Plans"
        id="Saved Meal Plans"
      >
        <option
          :value="mealplan.mealPlanId"
          v-for="mealplan in listOfMealPlans"
          :key="mealplan.mealPlanId"
        >
          {{ mealplan.name }}
        </option>
      </select>
    </div>

    <!-- Meal Plan Name Display -->
    <div>
      <label v-show="!visualParams.name" for="Meal Plan Name"
        >{{ mealPlan.name }}
        <span
          v-show="!visualParams.viewMode && mealPlan.name"
          @click="visualParams.name = true"
          >🖉</span
        ></label
      >
      <input
        v-show="!visualParams.viewMode && (!mealPlan.name || visualParams.name)"
        @blur="visualParams.name = false"
        type="text"
        placeholder="My Meal Plan"
        v-model="mealPlan.name"
        name="Meal Plan Name"
        required="true"
      />
    </div>
    <!-- Editing Buttons -->
    <div>
      <button
        type="button"
        v-show="!visualParams.viewMode && mealPlan.mealPlanId"
        @click.prevent="resetMealPlan()"
      >
        Create New
      </button>
      <button
        type="button"
        v-show="mealPlan.mealPlanId && !visualParams.viewMode"
        @click.prevent="clearMealPlan()"
      >
        Clear</button
      >&nbsp;
      <button
        type="button"
        v-show="!visualParams.viewMode"
        @click.prevent="saveMealPlan()"
      >
        Save As New Meal Plan
      </button>
      <button
        type="button"
        v-show="mealPlan.mealPlanId && !visualParams.viewMode"
        @click.prevent="editMealPlan()"
      >
        Save Changes
      </button>
    </div>
    <section id="plan-table">
        <section id="group" v-for="i of 7" :key="i">
          <p @click="this, (visualParams.dayIndex = i)">
            {{ visualParams.DAYS_OF_WEEK[i - 1] }}
          </p>
          <!-- Display view mode recipes -->
          <section
            v-show="visualParams.viewMode"
            v-for="recipe in mealPlan.mealList[i - 1].recipes"
            :key="recipe.recipeId"
          >
            <router-link
              :to="{ name: 'recipe', params: { id: recipe.recipeId } }"
              :class="recipe.recipeName"
              ><span class="recipe-name">&bullet; {{ recipe.recipeName }}</span>
            </router-link>
          </section>
          <!-- Display edit mode recipes -->
          <section
            v-show="!visualParams.viewMode"
            v-for="recipe in mealPlan.mealList[i - 1].recipes"
            :key="recipe.recipeId"
          >
            <span
              @click="
                this, (visualParams.dayIndex = i - 1);
                deleteRecipefromMeal(recipe);
              "
              >&bullet; {{ recipe.recipeName }} 🗑</span
            >
          </section>
          <span
            @click="
              visualParams.addMeal = true;
              visualParams.dayIndex = i - 1;
            "
            v-show="!visualParams.viewMode"
            >+ Add Recipes</span
          >
        </section>
    </section>
    <h4 v-show="!visualParams.viewMode">
      Select recipes below to add to
      {{ visualParams.DAYS_OF_WEEK[visualParams.dayIndex] }}
    </h4>
    <div
      v-show="!visualParams.viewMode"
      v-for="recipe in availableRecipes"
      :key="recipe.recipeId"
    >
      <span @click="addRecipetoMeal(recipe)">{{ recipe.recipeName }}</span>
      <router-link
        :to="{ name: 'recipe', params: { id: recipe.recipeId } }"
        target="_blank"
        :name="recipe.recipeName"
        :instructions="recipe.instructions"
        >👁</router-link
      >
    </div>
    <grocery-list v-if="visualParams.viewMode" :mealPlan="mealPlan" />
  </div>
</template>

<script>
import services from "../services/AuthService.js";
import GroceryList from "./GroceryList.vue";

export default {
  components: { GroceryList },
  data() {
    return {
      //Container for all variables for adjusting/modifying user view
      visualParams: {
        viewMode: true,
        addMeal: false,
        dayIndex: 0,
        selectedText: "",
        name: true,
        DAYS_OF_WEEK: [
          "Sunday",
          "Monday",
          "Tuesday",
          "Wednesday",
          "Thursday",
          "Friday",
          "Saturday",
        ],
      },
      mealPlan: {
        name: "",
        mealList: [
          { recipes: [], mealId: 0, mealName: "", timeOfDay: 0, userId: 0 },
          { recipes: [], mealId: 0, mealName: "", timeOfDay: 0, userId: 0 },
          { recipes: [], mealId: 0, mealName: "", timeOfDay: 0, userId: 0 },
          { recipes: [], mealId: 0, mealName: "", timeOfDay: 0, userId: 0 },
          { recipes: [], mealId: 0, mealName: "", timeOfDay: 0, userId: 0 },
          { recipes: [], mealId: 0, mealName: "", timeOfDay: 0, userId: 0 },
          { recipes: [], mealId: 0, mealName: "", timeOfDay: 0, userId: 0 },
        ],
        mealPlanId: 0,
        userId: 0,
        indices: "",
      },
      listOfMealPlans: [],
    };
  },
  name: "meal-plan",
  computed: {
    availableRecipes() {
      const publicRecipes = this.$store.state.recipes.map((el) => {
        return el.recipeId;
      });
      const privateRecipes = this.$store.state.myRecipes.map((el) => {
        return el.recipeId;
      });
      //this turns the array into a Set which doesn't like duplicates so it removes them, and then it turns the Set back into an array excluding any duplicates
      let uniqueSet = publicRecipes.concat(privateRecipes);
      uniqueSet = [...new Set(uniqueSet)];

      uniqueSet = uniqueSet.map((recipeId) => {
        //if in public recipes grab recipe from $store.recipes if in private recipes grab from $store.myRecipes
        if (publicRecipes.includes(recipeId)) {
          return this.$store.state.recipes.find((publicRecipes) => {
            return recipeId === publicRecipes.recipeId;
          });
        }
        if (privateRecipes.includes(recipeId)) {
          return this.$store.state.myRecipes.find((privateRecipes) => {
            return recipeId === privateRecipes.recipeId;
          });
        }
      });
      return uniqueSet;
    },
  },
  methods: {
    showSavedMealPlan() {
      this.mealPlan = this.listOfMealPlans.find((mealplan) => {
        return mealplan.mealPlanId == this.visualParams.selectedText;
      });
    },
    addRecipetoMeal(recipe) {
      let chkBool = false;
      this.mealPlan.mealList[this.visualParams.dayIndex].recipes.forEach(
        (r) => {
          if (recipe.recipeId === r.recipeId) {
            chkBool = true;
            alert("Recipe Already Exists On This Day");
          }
        }
      );
      if (!chkBool) {
        this.mealPlan.mealList[this.visualParams.dayIndex].recipes.push(recipe);
      }
      this.mealPlan.mealList[this.visualParams.dayIndex].mealId = 0;
    },
    deleteRecipefromMeal(recipe) {
      let recipeIndex = this.mealPlan.mealList[
        this.visualParams.dayIndex
      ].recipes.indexOf(recipe);
      this.mealPlan.mealList[this.visualParams.dayIndex].recipes.splice(
        recipeIndex,
        1
      );
      this.mealPlan.mealList[this.visualParams.dayIndex].mealId = 0;
    },
    editMealPlan() {
      if (this.mealPlan.name.trim().length > 0) {
        services.putMealPlan(this.mealPlan).then(() => {
          this.visualParams.viewMode = true;
          this.visualParams.name = true;
          this.mealPlan = {
            name: "",
            mealList: [
              { recipes: [], mealId: 0, mealName: "", timeOfDay: 0, userId: 0 },
              { recipes: [], mealId: 0, mealName: "", timeOfDay: 0, userId: 0 },
              { recipes: [], mealId: 0, mealName: "", timeOfDay: 0, userId: 0 },
              { recipes: [], mealId: 0, mealName: "", timeOfDay: 0, userId: 0 },
              { recipes: [], mealId: 0, mealName: "", timeOfDay: 0, userId: 0 },
              { recipes: [], mealId: 0, mealName: "", timeOfDay: 0, userId: 0 },
              { recipes: [], mealId: 0, mealName: "", timeOfDay: 0, userId: 0 },
            ],
            mealPlanId: 0,
            userId: 0,
            indices: "",
          };
          services.getMealPlan().then((resp) => {
            this.listOfMealPlans = resp.data;
            this.visualParams.selectedText = "";
          });
        });
      } else {
        alert("Invalid meal plan name");
      }
    },
    resetMealPlan() {
      this.mealPlan = {
        name: "",
        mealList: [
          { recipes: [], mealId: 0, mealName: "", timeOfDay: 0, userId: 0 },
          { recipes: [], mealId: 0, mealName: "", timeOfDay: 0, userId: 0 },
          { recipes: [], mealId: 0, mealName: "", timeOfDay: 0, userId: 0 },
          { recipes: [], mealId: 0, mealName: "", timeOfDay: 0, userId: 0 },
          { recipes: [], mealId: 0, mealName: "", timeOfDay: 0, userId: 0 },
          { recipes: [], mealId: 0, mealName: "", timeOfDay: 0, userId: 0 },
          { recipes: [], mealId: 0, mealName: "", timeOfDay: 0, userId: 0 },
        ],
        mealPlanId: 0,
        userId: 0,
        indices: "",
      };
      this.visualParams.selectedText = "";
      this.visualParams.name = true;
    },
    clearMealPlan() {
      this.mealPlan.mealList = [
        { recipes: [], mealId: 0, mealName: "", timeOfDay: 0, userId: 0 },
        { recipes: [], mealId: 0, mealName: "", timeOfDay: 0, userId: 0 },
        { recipes: [], mealId: 0, mealName: "", timeOfDay: 0, userId: 0 },
        { recipes: [], mealId: 0, mealName: "", timeOfDay: 0, userId: 0 },
        { recipes: [], mealId: 0, mealName: "", timeOfDay: 0, userId: 0 },
        { recipes: [], mealId: 0, mealName: "", timeOfDay: 0, userId: 0 },
        { recipes: [], mealId: 0, mealName: "", timeOfDay: 0, userId: 0 },
      ];
    },
    saveMealPlan() {
      this.mealPlan.indices = "";
      this.mealPlan.mealPlanId = 0;
      this.mealPlan.userId = 0;
      this.mealPlan.mealList.forEach((meal) => {
        meal.mealId = 0;
        meal.mealName = "";
        meal.timeOfDay = 0;
        meal.userId = 0;
      });
      if (this.mealPlan.name.trim().length > 0) {
        services.postMealPlan(this.mealPlan).then(() => {
          this.visualParams.viewMode = true;
          this.visualParams.name = true;
          this.mealPlan = {
            name: "",
            mealList: [
              { recipes: [], mealId: 0, mealName: "", timeOfDay: 0, userId: 0 },
              { recipes: [], mealId: 0, mealName: "", timeOfDay: 0, userId: 0 },
              { recipes: [], mealId: 0, mealName: "", timeOfDay: 0, userId: 0 },
              { recipes: [], mealId: 0, mealName: "", timeOfDay: 0, userId: 0 },
              { recipes: [], mealId: 0, mealName: "", timeOfDay: 0, userId: 0 },
              { recipes: [], mealId: 0, mealName: "", timeOfDay: 0, userId: 0 },
              { recipes: [], mealId: 0, mealName: "", timeOfDay: 0, userId: 0 },
            ],
            mealPlanId: 0,
            userId: 0,
            indices: "",
          };
          services.getMealPlan().then((resp) => {
            this.listOfMealPlans = resp.data;
            this.visualParams.selectedText = "";
          });
        });
      } else {
        alert("Invalid meal plan name");
      }
    },
  },
  created() {
    services.getMealPlan().then((response) => {
      // if (response.data.length > 0) {
      //   this.mealPlan = response.data[response.data.length - 1];
      // }
      this.listOfMealPlans = response.data;
    });
  },
};
</script>

<style scoped>
span:hover {
  color: gray;
  cursor: pointer;
}
.entirePage {
  display: flex;
  flex-direction: column;
  background-color: rgba(255, 255, 255, 0.7);
  -webkit-backdrop-filter: blur(10px);
  backdrop-filter: blur(10px);
  border-radius: 25px;
}
#plan-table {
  display: flex;
  justify-content: center;
  align-items: flex-start;
}
#plan-table #group {
  display: inline-block;
  border: black 1px solid;
  padding: 2px;
  flex: 1;
}
#plan-table #group section {
  text-align: left;
  padding-left: 5px;
}
button {
  margin-bottom: 10px;
}

@media only screen and (max-width: 800px) {
#plan-table{
  flex-direction: column;
  align-items: center;
}
#plan-table #group{
  width: 80vw;
}
}
</style>