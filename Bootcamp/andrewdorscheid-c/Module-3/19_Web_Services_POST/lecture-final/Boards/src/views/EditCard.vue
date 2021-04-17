<template>
  <div>
    <h1>Edit Card</h1>
    <card-form v-bind:cardId="parseInt($route.params.cardId)" v-bind:boardId="parseInt($route.params.boardId)" />
  </div>
</template>

<script>
import CardForm from "@/components/CardForm";

export default {
  components: {
    CardForm
  }
};
</script>
