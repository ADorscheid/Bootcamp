<template>
  <div class="city">
    <h1>{{city.name}}</h1>
    <h2>Details</h2>
    <table class="form">
      <tr>
        <td>Name</td>
        <td>
          {{city.name}}
        </td>
      </tr>
      <tr>
        <td>District</td>
        <td>
          {{city.district}}
        </td>
      </tr>
      <tr>
        <td>Country Code</td>
        <td>
          {{city.countryCode}}
        </td>
      </tr>
      <tr>
        <td>Population</td>
        <td>
          {{city.population}}
        </td>
      </tr>
    </table>
    <hr />
    <table class="form">
      <tr>
        <td><router-link tag="button" :to="{name: 'CityUpdate', params: {id: city.cityId}}">Modify city</router-link></td>
        <td><router-link tag="button" :to="{name: 'CityDelete', params: {id: city.cityId}}">Delete city</router-link></td>
      </tr>
    </table>

  </div>
</template>

<script>
export default {
  name: "city",
  props: {
    id: Number
  },
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
    getCity(id) {
      // TODO 03: Use the service to get data and populate the city data field
      console.log(id);
    }
  },
  created() {

  }
};
</script>

<style>
</style>