<template>
  <div class="city-add">
    <h1>Add City</h1>
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
          <button v-on:click="addCity">Add</button>
        </td>
      </tr>
    </table>
  </div>
</template>

<script>
export default {
  name: "city-add",
  props: {},
  data() {
    return {
      city: {
        cityId: 0,
        name: "",
        district: "",
        countryCode: "",
        population: 0
      }
    };
  },
  methods: {
    addCity() {
     // TODO 08: use the service to Add the city on the server (POST)


    }
  },
  created() {}
};
</script>

<style scoped>

</style>