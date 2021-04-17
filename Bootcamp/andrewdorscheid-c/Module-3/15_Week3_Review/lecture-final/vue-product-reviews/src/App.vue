<template>
  <div id="app">
    <!-- Place the Product review component here... -->
    <product-review />
  </div>
</template>

<script>
import ProductReview from './components/ProductReview.vue'
import apiService from './services/apiService.js'
export default {
  name: 'App',
  components: {
    ProductReview
  },
  created(){
    apiService.fetchReviews(this.$store);
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;

  max-width: 800px;
  margin: 60px auto 0px auto;
}
</style>
