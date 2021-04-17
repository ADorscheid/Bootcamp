<template>
  <div>
    <!-- TODO: Show an animation if loading, or the real page once loading is finished -->
    <img src="../assets/ping_pong_loader.gif" v-if="isLoading" />
    <div v-else>
      <!-- TODO: Display title (h1) and description (p) -->
      <h1>{{ card.title }}</h1>
      <p>{{ card.description }}</p>

      <!-- TODO: Add comments-list to the display (import the component)
                Pass the card.comments as a prop 
    -->
      <comments-list :comments="card.comments" />
    </div>
    <!-- TODO: Add a link to go back to the Board -->
    <router-link v-bind:to="{name: 'Board', params:{id:boardId}}">Back to Board</router-link>
  </div>
</template>

<script>
// TODO: Import BoardService.js to have access to our data functions
import boardService from "@/services/BoardService.js";
import CommentsList from "./CommentsList.vue";

export default {
  name: "card-detail",
  components: {
    CommentsList,
  },
  //  TODO: Create an empty card property in data (title, description, status, comments[])
  props: {
    cardId: Number,
    boardId: Number,
  },
  data() {
    return {
      card: {},
      isLoading: false,
    };
  },

  // TODO: Add an isLoading property to the data to manage the loading animation

  // TODO: Hook into the created lifecycle event to call getCard in boardService
  //        and populate the card
  created() {
    this.isLoading = true;
    boardService.getCard(this.boardId, this.cardId).then((returnedCard) => {
      this.isLoading = false;
      this.card = returnedCard;
    });
  },
};
</script>
