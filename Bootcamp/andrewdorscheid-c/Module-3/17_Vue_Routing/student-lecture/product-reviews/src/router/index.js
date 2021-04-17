import Vue from 'vue'
import VueRouter from 'vue-router'

Vue.use(VueRouter)
/*
  01: Create the home page and a route for the home page
    * Add Products.vue View, which contains ProductsList.vue component
    * Add a route to the routes table
*/
const routes = [


]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
