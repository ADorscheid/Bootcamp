<template>
  <cards-list :boardId="parseInt($route.params.id)"/>
</template>

<script>
import CardsList from '@/components/CardsList';

export default {
  components: {
    CardsList
  }
};
</script>
