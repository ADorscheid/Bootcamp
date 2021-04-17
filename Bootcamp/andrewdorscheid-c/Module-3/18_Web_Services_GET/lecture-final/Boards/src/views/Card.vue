<template>
  <card-detail v-bind:cardId="cardId" v-bind:boardId="boardId"/>
</template>

<script>
import CardDetail from '@/components/CardDetail';

export default {
  components: {
    CardDetail
  },
  data() {
    return {
      cardId: 0,
      boardId: 0,
    }
  },
  created() {
    this.cardId = parseInt(this.$route.params.cardID);
    this.boardId = parseInt(this.$route.params.boardID);
  }
};
</script>
