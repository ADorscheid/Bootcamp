import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'
import Board from '../views/Board.vue'
import Card from '../views/Card.vue'
import AddCard from '../views/AddCard.vue'
import EditCard from '../views/EditCard.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/board/:id',
    name: 'Board',
    component: Board
  },
  {
    path: '/board/:boardId/card/:cardId',
    name: 'Card',
    component: Card
  },
  {
    path: '/board/:boardId/card/create',
    name: 'AddCard',
    component: AddCard
  },
  {
    path: '/board/:boardId/card/:cardId/edit',
    name: 'EditCard',
    component: EditCard
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
