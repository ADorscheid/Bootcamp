import Vue from 'vue'
import VueRouter from 'vue-router'
// import Home from '@/views/Home.vue'
import Cities from '@/views/Cities.vue'
import City from '@/views/City.vue'
import CityAdd from '@/views/CityAdd.vue'
import CityUpdate from '@/views/CityUpdate.vue'
import CityDelete from '@/views/CityDelete.vue'
import About from '@/views/About.vue'
Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    redirect: {name: 'Cities'},
    name: 'Home'
  },
  {
    path: '/cities',
    name: 'Cities',
    component: Cities
  },
  {
    path: '/cities/:id',
    name: 'City',
    component: City
  },
  {
    path: '/cities/add',
    name: 'CityAdd',
    component: CityAdd
  },
  {
    path: '/cities/:id/update',
    name: 'CityUpdate',
    component: CityUpdate
  },
  {
    path: '/cities/:id/delete',
    name: 'CityDelete',
    component: CityDelete
  },
  {
    path: '/about',
    name: 'About',
    component: About
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
