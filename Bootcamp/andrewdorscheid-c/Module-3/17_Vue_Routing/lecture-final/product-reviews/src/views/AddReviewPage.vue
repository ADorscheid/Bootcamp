<template>
  <div>
      <h1>Add a Review</h1>
      <add-review :product-id="productId"/>
  </div>
</template>

<script>
import AddReview from '../components/AddReview.vue'
export default {
    components: {
        AddReview,
    },
    data(){
        return {
            productId: 0,
        }
    },
    created(){
        this.productId = parseInt( this.$route.params.id );
    }
}
</script>

<style scoped>

</style>