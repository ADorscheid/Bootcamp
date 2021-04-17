import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    people: [
      { id: 1, name: "Dan", age: 33, height: 69 },
      { id: 2, name: "Max", age: 31, height: 70 },
      { id: 3, name: "Ed", age: 48, height: 72 },
      { id: 4, name: "Amy", age: 31, height: 67 },
      { id: 5, name: "Chris", age: 25, height: 75 },
      { id: 6, name: "Seth", age: 23, height: 69 },
      { id: 7, name: "Kevin", age: 29, height: 73 },
      { id: 8, name: "Jordann", age: 19, height: 64 },
      { id: 9, name: "Josh", age: 22, height: 77 },
  ]
  },
  mutations: {
    ADD_PERSON(state, newPersonObject){
      // Set the new Id
      const id = state.people.length + 1;
      newPersonObject.id = id;

      // Add the new person to our data
      state.people.push(newPersonObject);
    }
  },
  actions: {
  },
  modules: {
  }
})
