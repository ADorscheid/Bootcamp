<template>
  <div class="well" :class="{selectedFilter: $store.state.filter === 0}">
    <span class="amount" v-on:click="updateFilter()">{{ averageRating }}</span>
    Average Rating
  </div>
</template>

<script>
export default {
  name: "average-summary",
  props: {
    productId : Number
  },
  methods: {
    updateFilter() {
      this.$store.commit("UPDATE_FILTER", 0);
    }
  },
  computed: {
    averageRating() {
      const reviews = this.$store.state.products.find(
        p => p.id == this.productId
      ).reviews;
      let sum = reviews.reduce((currentSum, review) => {
        return currentSum + review.rating;
      }, 0);
      if (sum === 0) {
        return 0;
      } else {
        return sum / reviews.length;
      }
    }
  }
};
</script>
