<template>
  <div class="home">
    <h1>Munch Munch, Yum!</h1>
    <h2 v-show="currentUser.userId">Welcome {{currentUser.username}}! (^-^)</h2>
    <h3>Public Recipes</h3>
    <recipe-list :recipeList="recipeList" />
    <router-link
      v-bind:to="{ name: 'profile' }"
      v-if="$store.state.token !== ''"
      ><h2 class="createmealplan">My Meal Plans</h2>
    </router-link>
    <div class="mealplan" v-if="$store.state.token===''">
    <router-link v-bind:to="{ name: 'login' }">
      <h2 class="createmealplan">Create Meal Plan</h2>
    </router-link>
    <table>
      <thead>
        <th>Sunday</th>
        <th>Monday</th>
        <th>Tuesday</th>
        <th>Wednesday</th>
        <th>Thursday</th>
        <th>Friday</th>
        <th>Saturday</th>
      </thead>
      <tbody>
        <td>
          <router-link v-bind:to="{ name: 'login' }">+ Add Recipes</router-link>
        </td>
        <td>
          <router-link v-bind:to="{ name: 'login' }">+ Add Recipes</router-link>
        </td>
        <td>
          <router-link v-bind:to="{ name: 'login' }">+ Add Recipes</router-link>
        </td>
        <td>
          <router-link v-bind:to="{ name: 'login' }">+ Add Recipes</router-link>
        </td>
        <td>
          <router-link v-bind:to="{ name: 'login' }">+ Add Recipes</router-link>
        </td>
        <td>
          <router-link v-bind:to="{ name: 'login' }">+ Add Recipes</router-link>
        </td>
        <td>
          <router-link v-bind:to="{ name: 'login' }">+ Add Recipes</router-link>
        </td>
      </tbody>
    </table>
    </div>
  </div>
</template>

<script>
import RecipeList from "../components/recipeList.vue";
export default {
  name: "home",
  components: { RecipeList },
  computed: {
    currentUser() {
      return this.$store.state.user;
    },
    recipeList() {
      return this.$store.state.recipes;
    },
  },
};
</script>

<style scoped>
span:hover {
  color: white;
}
a {
  padding-left: 15px;
}
table {
  border-collapse: collapse;
  width:80%; 
  margin-left:10%; 
  margin-right:10%;
  background-color: rgba(255, 255, 255, 0.7);
  -webkit-backdrop-filter: blur(10px);
  backdrop-filter: blur(10px);
  

}
th {
  border-left: white 2px solid;
  border-right: white 2px solid;
  border-top: white 2px solid;
}
td {
  border-left: white 2px solid;
  border-right: white 2px solid;
  border-bottom: white 2px solid;
}
button {
  margin-bottom: 10px;
}

h1, h2 {
  color: black;
  text-transform: capitalize;
}

.createmealplan:hover {
  cursor: pointer;
  color: gray;
}


</style>