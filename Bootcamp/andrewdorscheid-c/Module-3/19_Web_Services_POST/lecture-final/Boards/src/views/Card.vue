<template>
  <card-detail v-bind:card-id="parseInt($route.params.cardId)"/>
</template>

<script>
import CardDetail from '@/components/CardDetail';

export default {
  components: {
    CardDetail
  }
};
</script>
