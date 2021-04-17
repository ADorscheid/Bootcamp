<template>


    <!-- v-on:click="filter = 0"
    " -->
  <div
    class="well"
    v-on:click="setFilter(0)"
    v-bind:class="{'selected-well': $store.state.filter === 0 }"
  >
    <span class="amount"> {{ averageRating }} </span>
    Average Rating
  </div>
</template>

<script>
export default {
  name: "AverageSummary",
//   props: {
//       theReviewArray: Array,
//   },
  data(){
      return {
          
      }
  },
  computed: {
    averageRating() {
      // Calculate the average rating of all the reviews (add ratings of all reviews then divide by the count)
      if (this.$store.state.reviews.length === 0) {
        return 0;
      }

      let sum = this.$store.state.reviews.reduce((accum, review) => {
        return accum + review.rating;
      }, 0);
      return (sum / this.$store.state.reviews.length).toFixed(2);
    },

  },
  methods: {
    setFilter(newFilter){
      // Call the Vuex mutation to set the new value for filter
      this.$store.commit('UPDATE_FILTER', newFilter);
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