<template>
  <div>
    <new-recipe v-if="!recipeId"/>
    <edit-recipe v-if="recipeId"/>
   
  </div>
</template>

<script>
import EditRecipe from '../components/EditRecipe.vue'
import newRecipe from "../components/NewRecipe.vue"

export default {
  components: {
    newRecipe,
    EditRecipe,
    
  },
  computed: {
    recipeId(){
      if(this.$route.params){
        return this.$route.params.id;
      }
      return ""
    }
  },
}
</script>

<style>

</style>