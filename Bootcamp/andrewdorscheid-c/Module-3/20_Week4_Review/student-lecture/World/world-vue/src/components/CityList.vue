<template>
  <table>
    <thead>
      <tr>
        <td>Id</td>
        <td>Name</td>
        <td>District</td>
        <td>Country</td>
        <td class="right-justified">Population</td>
      </tr>
    </thead>
    <tbody>
      <tr v-for="city in cities" :key="city.cityId">
        <td>{{city.cityId}}</td>
        <td>
          <router-link :to="{name: 'City', params: {id: city.cityId}}">{{city.name}}</router-link>
        </td>
        <td>{{city.district}}</td>
        <td>{{city.countryName}}</td>
        <td class="right-justified">{{city.population}}</td>
      </tr>
    </tbody>
  </table>
</template>

<script>
export default {
  name: "city-list",
  props: {
    cities: Array
  },
  data() {
    return {};
  },
  methods: {},
  computed: {}
};
</script>

<style scoped>
table {
  margin: auto;
  display: table;
  border-collapse: separate;
  border-spacing: 2px;
  border-color: grey;
  width: 80%;
  margin-bottom: 1rem;
  color: #212529;
}
thead td {
    font-weight: 600;
    border-bottom: 1px solid darkblue;
}
td {
  padding: 10px;
}
tr:nth-child(even) {
  background-color: darkseagreen;
}
.right-justified {
    text-align: right;
}
</style>