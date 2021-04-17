<template>
  <div class="city-update">
    <h1>Update City {{city.name}}</h1>
    <table class="form">
      <tr>
        <td>Name</td>
        <td>
          <input type="text" v-model="city.name" />
        </td>
      </tr>
      <tr>
        <td>District</td>
        <td>
          <input type="text" v-model="city.district" />
        </td>
      </tr>
      <tr>
        <td>Country Code</td>
        <td>
          <input type="text" v-model="city.countryCode" />
        </td>
      </tr>
      <tr>
        <td>Population</td>
        <td>
          <input type="number" v-model.number="city.population" />
        </td>
      </tr>
      <tr>
        <td></td>
        <td>
          <button v-on:click="saveCity">Save</button>
        </td>
      </tr>
    </table>
    <hr />
    <div>
      <router-link :to="{name: 'City', params: {id: city.cityId}}">Back to Details page</router-link>
    </div>
  </div>
</template>

<script>
export default {
  name: "city-update",
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
      // TODO 04: use the service to get the city given an id
      console.log(id);
    },
    saveCity() {
      // TODO 05: use the service to Update the city on the server (PUT)
    }
  },
  created() {
    
  }
};
</script>

<style>
</style>