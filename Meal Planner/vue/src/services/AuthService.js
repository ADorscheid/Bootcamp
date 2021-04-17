import axios from 'axios';

export default {

  login(user) {
    return axios.post('/login', user);
  },

  register(user) {
    return axios.post('/register', user);
  },

  getPublicRecipes() {
    return axios.get('/recipes');
  },

  getMyRecipes(user) {
    return axios.get('/recipes/myrecipes', user);
  },

  addRecipe(recipe) {
    return axios.post('/recipes', recipe);
  },

  putRecipe(recipe) {
    return axios.put('/recipes', recipe);
  },

  getIngredients(recipe) {
    return axios.get(`/recipeingredients/${recipe.recipeId}`);
  },

  getAllIngredients() {
    return axios.get('/ingredient');
  },

  postMealPlan(mealPlan) {
    return axios.post('/mealplan', mealPlan);
  },
  getMealPlan() {
    return axios.get('/mealplan');
  },
  putMealPlan(mealplan) {
    return axios.put('/mealplan', mealplan)
  }
}
