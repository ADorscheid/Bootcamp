import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    filter: 0,
    products: [
      {
        id: 1,
        name: "Cigar Parties for Dummies",
        description: "Host and plan the perfect cigar party for all of your squirrelly friends.",
        reviews: [
          {
            id: 1,
            reviewer: 'Malcolm Gladwell',
            title: 'What a book!',
            review:
              "It certainly is a book. I mean, I can see that. Pages kept together with glue and there's writing on it, in some language.",
            rating: 3,
            favorited: false
          },
          {
            id: 2,
            reviewer: 'Tim Ferriss',
            title: 'Had a cigar party started in less than 4 hours.',
            review:
              "It should have been called the four hour cigar party. That's amazing. I have a new idea for muse because of this.",
            rating: 4,
            favorited: false
          },
          {
            id: 3,
            reviewer: 'Ramit Sethi',
            title: 'What every new entrepreneurs needs. A door stop.',
            review:
              "When I sell my courses, I'm always telling people that if a book costs less than $20, they should just buy it. If they only learn one thing from it, it was worth it. Wish I learned something from this book.",
            rating: 1,
            favorited: false
          },
          {
            id: 4,
            reviewer: 'Gary Vaynerchuk',
            title: 'And I thought I could write',
            review:
              "There are a lot of good, solid tips in this book. I don't want to ruin it, but prelighting all the cigars is worth the price of admission alone.",
            rating: 3,
            favorited: false
          }
        ]
      },
      {
        id: 2,
        name: "Personal Finance for Dummies",
        description: "",
        reviews: []
      },
      {
        id: 3,
        name: "Project Management for Dummies",
        description: "",
        reviews: []
      },
      {
        id: 4,
        name: "Critical Thinking Skills for Dummies",
        description: "",
        reviews: []
      },
      {
        id: 5,
        name: "Home Maintenance for Dummies",
        description: "",
        reviews: []
      }
    ]
  },
  mutations: {
    ADD_REVIEW(state, payload) {
      const productId = payload.productId;
      const review = payload.review;
      const product = this.state.products.find(p => p.id == productId);
      if (product){
        // Get the largest reviewId in the array so we can determine the next id
        const max = product.reviews.reduce( (mx, review) => Math.max(mx, review.id), 0);
        review.id = max+1;
        product.reviews.unshift(review);
      }
    },
    UPDATE_FILTER(state, filter) {
      state.filter = filter;
    },
    FLIP_FAVORITED(state, reviewToChange) {
      reviewToChange.favorited = ! reviewToChange.favorited;
    },
  },
  actions: {
  },
  modules: {
  },
  strict: true
})
