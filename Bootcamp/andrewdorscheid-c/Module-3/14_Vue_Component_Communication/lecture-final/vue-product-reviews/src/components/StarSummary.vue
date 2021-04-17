<template>
  <div
    v-on:click="setFilter(nStars)"
    v-bind:class="{
      well: true,
      'selected-well': $store.state.filter === nStars,
    }"
  >
    <span class="amount">{{ nStarReviews[nStars - 1] }}</span>
    {{ nStars }} Star Review
  </div>
</template>

<script>
export default {
  name: "StarSummary",
  props: {
    nStars: Number,
  },
  computed: {
    nStarReviews() {
      let result = [0, 0, 0, 0, 0];
      this.$store.state.reviews.forEach((rev) => {
        result[rev.rating - 1]++;
      });
      return result;
    },
  },
  methods: {
    setFilter(newFilter) {
      // Call the Vuex mutation to set the new value for filter
      this.$store.commit("UPDATE_FILTER", newFilter);
    },
  },
};
</script>

<style scoped>
div.main div.well-display div.well {
  display: inline-block;
  width: 15%;
  border: 1px black solid;
  border-radius: 6px;
  text-align: center;
  margin: 0.25rem;
  cursor: pointer;
}

div.main div.well-display div.well span.amount {
  color: darkslategray;
  display: block;
  font-size: 2.5rem;
}
/* Add a style to Mark which rating is selected */
.selected-well {
  border-color: blue;
  box-shadow: 0px 0px 5px 5px lightblue;
}
div.main div.well-display div.well:hover {
  box-shadow: 0px 0px 5px 5px lightgray;
}

</style>