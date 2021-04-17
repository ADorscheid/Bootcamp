<template>
  <div class="main">
    <h2>Product Reviews for {{ name }}</h2>
    <p class="description">{{ description }}</p>
    <!-- <input type="text" v-model="name" />
    <br />
    <input type="text" v-model.lazy="description" /> -->

    <!-- A single review -->

    <div class="review" v-for="review in reviews" v-bind:key="review.id" v-bind:class="{fav: review.favorite, someOtherClass: review.rating > 3}">
      <h4>{{review.reviewer}}</h4>
      <div class="rating">
        <img src="../assets/star.png" class="ratingStar" v-for="n in review.rating" v-bind:key="n" />

      </div>
      <h3>{{review.title}}</h3>
      <p>{{review.review}}</p>

<!-- Add the checkbox for Favorite? -->
    <div>
        Favorite? 
        <input type="checkbox" v-model="review.favorite" />
    </div>

    </div>
  </div>
</template>

<script>
export default {
  name: "product-review",
  // data() is a function that returns an object full of properties
  data() {
    return {
      name: "Cigar Parties for Dummies",
      description:
        "Host and plan the perfect cigar party for all your squirelly friends",
      // Reviews data
      reviews: [
        {
          id: 1,
          reviewer: "Malcolm Gladwell",
          title: "What a book!",
          review:
            "It certainly is a book. I mean, I can see that. Pages kept together with glue and there's writing on it, in some language.",
          rating: 3,
          favorite: false,
        },
        {
          id: 2,
          reviewer: "Craig Castelaz",
          title: "Better than a swift kick in the butt!",
          review: "My bar is low.",
          rating: 4,
          favorite: false,
        },
      ],
    };
  },
};
</script>

<style scoped>
div.main {
  margin: 1rem 0;
}

div.main div.well-display {
  display: flex;
  justify-content: space-around;
}

div.main div.well-display div.well {
  display: inline-block;
  width: 15%;
  border: 1px black solid;
  border-radius: 6px;
  text-align: center;
  margin: 0.25rem;
}

div.main div.well-display div.well span.amount {
  color: darkslategray;
  display: block;
  font-size: 2.5rem;
}

div.main div.review {
  border: 1px black solid;
  border-radius: 6px;
  padding: 1rem;
  margin: 10px;
}

div.main div.review div.rating {
  height: 2rem;
  display: inline-block;
  vertical-align: top;
  margin: 0 0.5rem;
}

div.main div.review div.rating img {
  height: 100%;
}

div.main div.review p {
  margin: 20px;
}

div.main div.review h3 {
  display: inline-block;
}

div.main div.review h4 {
  font-size: 1rem;
}

input[type="text"] {
  padding: 5px 10px;
  margin: 5px 10px;
  background-color: beige;
  border: 1px solid lightblue;
  border-radius: 5px;
  box-shadow: 2px 2px 2px 2px lightblue;
  width: 300px;
}

div.review.fav {
    background-color: lightyellow;
}
</style>