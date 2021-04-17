/****************************************************
* ProductDetail.vue HTML and Script
****************************************************/
<template>
  <div id="product-detail" class="main">
    <h1>{{ product.name }}</h1>
    <p class="description">{{ product.description }}</p>
    <div class="actions">
      <router-link :to="{ name: 'products' }">Back to Products</router-link>
      &nbsp; |
      <router-link :to="{ name: 'add-review', params: {id: product.id}}">Add Review</router-link>
    </div>
    <div class="well-display">
      <average-summary :productId="productId" />
      <star-summary :productId="productId" :rating="1" />
      <star-summary :productId="productId" :rating="2" />
      <star-summary :productId="productId" :rating="3" />
      <star-summary :productId="productId" :rating="4" />
      <star-summary :productId="productId" :rating="5" />
    </div>
    <review-list :productId="productId" />
  </div>
</template>

<script>
import AverageSummary from "@/components/AverageSummary";
import StarSummary from "@/components/StarSummary";
import ReviewList from "@/components/ReviewList.vue";

export default {
  name: "product-detail",
  components: {
    AverageSummary,
    StarSummary,
    ReviewList,
  },
  // TODO: Define a data item to store the desired product id
  data() {
    return {
      productId: 0,
    };
  },

  computed: {
    // TODO: Define a computed product object which looks up the appropriate product from the store
    product() {
      // For now, just an empty product
      return this.$store.state.products.find((p) => {
        return p.id === this.productId;
      });
    },
  },

  /*
    created is a Vue Lifecycle Hook, which is explained in greater detail in the 
    JavaScript Web Services topic. For now, it should be enough to understand the 
    code inside the method is executed each time a new instance of ProductDetail 
    is created.
    */
  created() {
    // TODO: Set the product id we are interested in
    this.productId = parseInt(this.$route.params.id);
  },
};
</script>

<style scoped>
</style>