<template>
  <div>
    <h1>Products</h1>
    <products-list />
  </div>
</template>

<script>
import ProductsList from "@/components/ProductsList.vue";
export default {
  name: "Products",
  components: {
    ProductsList,
  },
};
</script>

<style scoped>
</style>