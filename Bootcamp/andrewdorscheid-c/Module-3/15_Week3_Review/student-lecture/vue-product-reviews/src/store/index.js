import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)
export default new Vuex.Store({
  strict: true,
  state: {
    name: "Cigar Parties for Dummies",
    description:
      "Host and plan the perfect cigar party for all your squirelly friends",

    // Create a variable to hold the current ratings Filter value
    filter: 0,
    reviews: [],
    // reviews: [
    //   {
    //     id: 1,
    //     reviewer: "Malcolm Gladwell",
    //     title: "What a book!",
    //     review:
    //       "It certainly is a book. I mean, I can see that. Pages kept together with glue and there's writing on it, in some language.",
    //     rating: 3,
    //     favorite: false,
    //   },
    //   {
    //     id: 2,
    //     reviewer: "Craig Castelaz",
    //     title: "Better than a swift kick in the butt!",
    //     review: "My bar is low.",
    //     rating: 4,
    //     favorite: false,
    //   },
    //   {
    //     id: 3,
    //     reviewer: "Ed",
    //     title: "Better than Cats",
    //     review: "I loved it.  It was great.  It was better than CAts.",
    //     rating: 2,
    //     favorite: false,
    //   },
    //   {
    //     id: 4,
    //     reviewer: "Lace",
    //     title: "It's no FizzBuzz",
    //     review:
    //       "Not the most constructive how-to. I think the author may be nuts.",
    //     rating: 2,
    //     favorite: false,
    //   },
    //   {
    //     id: 5,
    //     reviewer: "Joe",
    //     title: "Pick up the pace",
    //     review: "Like War and Peace, but much slower.",
    //     rating: 5,
    //     favorite: false,
    //   },
    //   {
    //     id: 6,
    //     reviewer: "Max",
    //     title: "Dummy",
    //     review: "The writer needs to read a 'writing for dummies' book.",
    //     rating: 1,
    //     favorite: false,
    //   },
    // ],

  },
  mutations: {
    UPDATE_FILTER(state, newFilter){
      state.filter = newFilter;
    },
    LOAD_REVIEWS(state, reviews){
      state.reviews = reviews;
    },
  },
  actions: {
  },
  modules: {
  }
})
