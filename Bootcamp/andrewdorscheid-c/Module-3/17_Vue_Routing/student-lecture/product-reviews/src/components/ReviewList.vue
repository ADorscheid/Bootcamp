<template>
  <div class="reviews">
    <review-display
      v-for="review in filteredReviews"
      v-bind:key="review.title"
      v-bind:review="review"
    />
  </div>
</template>

<script>
import ReviewDisplay from "./ReviewDisplay";

export default {
  name: "review-list",
  components: {
    ReviewDisplay
  },
  props: {
    productId: Number
  },
  computed: {
    filteredReviews() {
      const product = this.$store.state.products.find(
        p => p.id == this.productId
      );
      const reviewsFilter = this.$store.state.filter;
      return product.reviews.filter(review => {
        return reviewsFilter === 0 ? true : reviewsFilter === review.rating;
      });
    }
  }
};
</script>

<style>

div.well-display {
  display: flex;
  justify-content: space-around;
}

div.well-display div.well {
  display: inline-block;
  width: 15%;
  border: 1px black solid;
  border-radius: 6px;
  text-align: center;
  margin: 0.25rem;
}

div.well-display div.well span.amount {
  color: darkslategray;
  display: block;
  font-size: 2.5rem;
}

div.well-display div.well {
  cursor: pointer;
}
</style>
