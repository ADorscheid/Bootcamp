<template>
  <div class="well" :class="{selectedFilter: $store.state.filter === rating}">
    <span class="amount" v-on:click="updateFilter()">{{ stars }}</span>
    {{ rating }} Star Review{{ stars === 1 ? '' : 's' }}
  </div>
</template>

<script>
export default {
  name: "star-summary",
  props: {
    rating: Number,
    productId: Number,
  },
  methods: {
    updateFilter() {
      this.$store.commit("UPDATE_FILTER", parseInt(this.rating));
    },
  },
  computed: {
    stars() {
      const reviews = this.$store.state.products.find(
        (p) => p.id == this.productId
      ).reviews;
      return reviews.reduce((currentCount, review) => {
        return currentCount + (review.rating === parseInt(this.rating) ? 1 : 0);
      }, 0);
    },
  },
};
</script>
