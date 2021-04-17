<template>
  <div>
    <section v-for="recipe in recipeList" :key="recipe.recipeId">
      <router-link
        :to="{ name: 'recipe', params: { id: recipe.recipeId } }"
        :class="recipe.recipeName"
        ><span class="recipe-name">{{ recipe.recipeName }}</span>
       <div class="image">
        <img :src="recipe.imgUrl">
        </div>
        <div>Cook Time: {{ recipe.cookTime }}min</div>
        </router-link>
    </section>
  </div>
</template>

<script>
export default {
  name: "recipe-list",
  props: {
    recipeList: Array,
  },
};
</script>

<style scoped>
div {
  display: flex;
  flex-wrap: wrap;
  justify-content: space-around;
  align-content: space-around;
}
section{
  width: 400px;
  height: 300px;
  background-color: rgba(0,0,0,0.5);
  margin: 10px;
  border-radius: 15px;
}
a {
  display: inline-block;
  width: 400px;
  height: 300px;
  background-color: rgba(255,255,255,0.7);
  -webkit-backdrop-filter: blur(10px);
  backdrop-filter: blur(10px);
  position: relative;
  left: -1px;
  top: -1px;
  border-radius: 15px;
}
a:hover {
  left: -3px;
  top: -3px;
}
.image{
  width: 300px;
  height: 225px;
  margin-left: auto;
  margin-right: auto;
  overflow: hidden;
  background-color: white;
  border-radius: 10px;
}
img{
  width: 300px;
  
}
.recipe-name{
  font-size: 110%;
  font-weight: bold;
}
</style>