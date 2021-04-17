<template>
  <div class="class-list">
    <form @submit.prevent="addNewPerson">
      <table class="class-table">
        <thead>
          <tr>
            <td>Name</td>
            <td>Age</td>
            <td>Height</td>
            <td></td>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>
              <input type="text" required v-model="newPerson.name" />
            </td>
            <td>
              <input type="number" required v-model.number="newPerson.age" />
            </td>
            <td>
              <input type="number" required v-model.number="newPerson.height" />
            </td>
            <td>
              <input type="submit" value="Add" />
            </td>
          </tr>
          <tr v-for="person in $store.state.people" :key="person.id">
            <td>{{person.name}}</td>
            <td>{{person.age}}</td>
            <td>{{person.height}}</td>
            <td></td>
          </tr>
        </tbody>
      </table>
    </form>
  </div>
</template>

<script>
export default {
  data() {
    return {
      newPerson: {},
    };
  },
  methods: {
      addNewPerson() {
          // Add the new person to array
          this.$store.commit('ADD_PERSON', this.newPerson);
          this.newPerson = {};
      }
  }
};
</script>

<style scoped>
.class-list {
  margin: 0 auto;
}
.class-table {
  margin: 0 auto;
}
</style>