<template>
  <div class="cities">
    <h1>List Cities</h1>
    <table class="form">
      <tr>
        <td>Country Code:</td>
        <td>
          <input
            type="text"
            v-model="searchCountry"
            @change="searchDistrict = (searchCountry) ? searchDistrict : '' ;"
            placeholder="Country Code"
          />
        </td>
        <td>District:</td>
        <td>
          <input
            type="text"
            v-model="searchDistrict"
            :disabled="!searchCountry"
            placeholder="State"
          />
        </td>
        <td>
          <button @click="getData">Search</button>
        </td>
      </tr>
    </table>

    <city-list :cities="cities"></city-list>
  </div>
</template>

<script>
import CityList from "@/components/CityList.vue";
import axios from 'axios';
export default {
  name: "cities",
  components: {
    "city-list": CityList
  },
  data() {
    return {
      searchCountry: "",
      searchDistrict: "",
      cities: []
    };
  },
  methods: {
    getData() {
      // TODO 01: use a service to get data from the server populate the cities array
      // TODO 02: add in the query string parameters

      // This is the url...
      let url = `${process.env.VUE_APP_REMOTE_API}/cities`;
      axios.get(url)
        .then(
          (resp) =>{
            this.cities = resp.data;
          }
        )

    }
  },
  created() {
    // TODO 02: Get QS parameters from the route and populate them in data
  }
};
</script>

<style scoped>
</style>