<template>
  <div class="recipe">
    <h2>
      {{ recipe.recipeName }}
      <div>
        <button
          type="button"
          v-show="recipe.userId === $store.state.user.userId"
          @click="editRecipe()"
        >
          Edit Recipe
        </button>
      </div>
      <img v-bind:src="recipe.imgUrl" />
    </h2>
    <div class="Details">
      <span class="detailSpan">{{dishType[recipe.type - 1]}} &emsp;</span><br class="lineBreak">
      
      <span class="detailSpan">Servings: </span>{{recipe.servings}}&emsp; <br class="lineBreak">
      <span class="detailSpan">Cook Time: </span>{{recipe.cookTime}} Minutes
    </div>
    <section class="ingredients">
      <h4>Ingredients:</h4>
      <p v-for="ingredient of ingredients" :key="ingredient.ingredientId">
        {{ ingredient.quantity }} {{ ingredient.unit }}
        {{ ingredient.ingredientName }}
      </p>
    </section>
    <section class="instructions">
      <h4>Instructions:</h4>
      <p v-for="num of instructions.length" :key="num">
        <span>{{ num }}.</span> {{ instructions[num - 1] }}
      </p>
    </section>
  </div>
</template>

<script>
import authServices from "../services/AuthService.js";

export default {
  data() {
    return {
      recipe: {},
      // contains name, quantity, and unit of each ingredient
      ingredients: [{}],
      dishType: ["Main Dish", "Side Dish", "Beverage", "Dessert", "Appetizer"],
    };
  },

  methods: {
    editRecipe() {
      this.$router.push(`/recipes/edit/${this.recipe.recipeId}`);
    },
  },
  computed: {
    instructions() {
      return this.recipe.instructions.split("|||");
    },
  },
  created() {
    this.recipe = this.$store.state.myRecipes.find((recipe) => {
      return this.$route.params.id == recipe.recipeId;
    });
    if (!this.recipe) {
      this.recipe = this.$store.state.recipes.find((recipe) => {
        return this.$route.params.id == recipe.recipeId;
      });
    }

    //TODO: Replace following code with api call to get ingredients
    authServices.getIngredients(this.recipe).then((resp) => {
      this.ingredients = resp.data;
    });
  },
};
</script>

<style scoped>
img {
  max-width: 50vw;
}
span {
  font-size: 125%;
}
.recipe {
  display: grid;
  grid-template-areas:
    "title title title title title title title title"
    "Detail Detail Detail Detail Detail Detail Detail Detail"
    "ingredients instructions instructions instructions instructions instructions instructions instructions";
}
h2 {
  grid-area: title;
}
.ingredients {
  grid-area: ingredients;
  text-align: left;
  background-color: rgba(255, 255, 255, 0.7);
  -webkit-backdrop-filter: blur(10px);
  backdrop-filter: blur(10px);
  padding: 0px 20px;
  margin-right: 1vw;
  border-radius: 15px;
}
.instructions {
  grid-area: instructions;
  text-align: left;
  background-color: rgba(255, 255, 255, 0.7);
  -webkit-backdrop-filter: blur(10px);
  backdrop-filter: blur(10px);
  padding: 0px 20px;
  border-radius: 15px;
  display: flex;
  flex-direction: column;
  min-width: 78%;
}
.Details {
  grid-area: Detail;
  background-color: rgba(255, 255, 255, 0.7);
  -webkit-backdrop-filter: blur(10px);
  backdrop-filter: blur(10px);
  border-radius: 15px;
  width: 50vw;
  margin-bottom: 1vh;
  margin-left: auto;
  margin-right: auto;
}
.detailSpan {
  font-size: 100%;
  font-weight: bold;
}
.lineBreak {
  display: none;
}

@media only screen and (max-width: 800px) {
  .recipe {
  display: grid;
  grid-template-areas:
    "title"
    "Detail"
    "ingredients"
    "instructions";
 } 
 .ingredients {
   width: 47%;
   margin: 0px auto 10px auto;
 }
 .lineBreak {
   display: inline;
 }
 

}
</style>