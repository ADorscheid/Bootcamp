<template>
  <div id="app">
    <class-container />
  </div>
</template>

<script>
import ClassContainer from './components/ClassContainer.vue'

export default {
  name: 'App',
  components: {
    ClassContainer
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;

  max-width: 800px;
  margin: 60px auto 0px auto;
}
</style>
