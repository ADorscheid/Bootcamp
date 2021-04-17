<template>
  <div>
    <h1>Add New Card</h1>
    <card-form v-bind:boardId="parseInt($route.params.boardId)" />
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
