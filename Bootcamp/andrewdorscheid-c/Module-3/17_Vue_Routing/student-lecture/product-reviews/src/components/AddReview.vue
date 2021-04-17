<template>
  <form v-on:submit.prevent="addNewReview">
    <div class="form-element">
      <label for="reviewer">Name:</label>
      <input id="reviewer" type="text" v-model="newReview.reviewer" />
    </div>
    <div class="form-element">
      <label for="title">Title:</label>
      <input id="title" type="text" v-model="newReview.title" />
    </div>
    <div class="form-element">
      <label for="rating">Rating:</label>
      <select id="rating" v-model.number="newReview.rating">
        <option value="1">1 Star</option>
        <option value="2">2 Stars</option>
        <option value="3">3 Stars</option>
        <option value="4">4 Stars</option>
        <option value="5">5 Stars</option>
      </select>
    </div>
    <div class="form-element">
      <label for="review">Review</label>
      <textarea id="review" v-model="newReview.review"></textarea>
    </div>
    <div class="actions">
      <button v-on:click.prevent="resetForm" type="cancel">Cancel</button>
      <button>Submit</button>
    </div>
  </form>
</template>

<script>
export default {
  name: "add-review",
  props: {
    productId: Number,
  },
  data() {
    return {
      newReview: {
        id: 0,
        reviewer: "",
        title: "",
        rating: 0,
        review: "",
        favorited: false,
      },
    };
  },
  methods: {
    addNewReview() {
      this.$store.commit("ADD_REVIEW", { productId: this.productId, review: this.newReview});
      // TODO: send the visitor back to the product page to see the new review
    },
    resetForm() {
      this.newReview = {};
      // TODO: send the visitor back to the product page without adding the new review
    },
  },
};
</script>

<style scoped>
.error {
  font-weight: bold;
  color: red;
}
input[type="text"], select, textarea {
  padding: 5px 10px;
  margin: 5px 10px;
  background-color: beige;
  border: 1px solid lightblue;
  border-radius: 5px;
  box-shadow: 2px 2px 2px 2px lightblue;
  width: 300px;
}

div.form-element {
  margin-top: 10px;
}
div.form-element > label {
  display: block;
}
div.form-element > input,
div.form-element > select {
  height: 30px;
  width: 300px;
}
div.form-element > textarea {
  height: 60px;
  width: 300px;
}
form > input[type="button"] {
  width: 100px;
}
form > input[type="submit"] {
  width: 100px;
  margin-right: 10px;
}
</style>
