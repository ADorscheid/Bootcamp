<template>
  <div class="city-delete">
    <h1>Wanna DELETE City {{city.name}}?</h1>
    <table class="form"><tr><td><button v-on:click="deleteCity">Yes!</button></td></tr></table>
    
    <div>
      <hr/>
      <router-link :to="{name: 'City', params: {id: city.cityId}}">Cancel</router-link>
    </div>
  </div>
</template>

<script>
export default {
  name: "city-delete",
  props: {
    id: Number
  },
  data() {
    return {
      city: null
    };
  },
  methods: {
    getCity(id) {
      // TODO 06: Use the service to get data and populate the city data field
      console.log(id);

    },
    deleteCity() {
      // TODO 07: use the service to Delete the city on the server (DELETE)
    }
  },
  created() {
    
  }
};
</script>

<style>
</style>