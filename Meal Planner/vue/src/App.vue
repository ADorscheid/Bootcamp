<template>
  <div id="app">
    <div id="nav">
      <router-link v-bind:to="{ name: 'home' }">Home</router-link>&nbsp;|&nbsp;
      <router-link
        v-bind:to="{ name: 'login' }"
        v-if="$store.state.token === ''"
        >Login</router-link
      >
      <router-link
        v-bind:to="{ name: 'profile' }"
        v-if="$store.state.token !== ''"
        >{{ currentUser.username }} </router-link 
        
      > |
      <router-link
        v-bind:to="{ name: 'logout' }"
        v-if="$store.state.token != ''"
      >
        Logout</router-link
      >
    </div>
    <router-view v-if="isLoaded" />
  </div>
</template>

<script>
import authServices from '@/services/AuthService.js';

export default {
  data() {
    return{
      isLoaded: false
    }
  },
  computed: {
    currentUser() {
      return this.$store.state.user;
    },
  },
  created() {
    authServices.getPublicRecipes().then((response)=>{
      this.$store.commit("SET_PUBLIC_RECIPES",response.data);
      if (this.$store.state.token===''){
        this.isLoaded=true;
      }
    });
    if (this.$store.state.token!==''){
      authServices.getMyRecipes(this.$store.state.user).then((response)=>{
        this.$store.commit("SET_MY_RECIPES",response.data);
        this.isLoaded = true;
      });
    }
  }
};
</script>

<style>
@import url('https://fonts.googleapis.com/css?family=Sriracha&display=swap');

body {
  text-align: center;
  color: black;
  background-color: rgba(255,255,255,0.7);
  background-image: url("https://trello-backgrounds.s3.amazonaws.com/SharedBackground/2398x1600/9195f991e5dcaddec7c4e677ec7a4bcf/photo-1591189863430-ab87e120f312.jpg");
  background-repeat: no-repeat;
  background-attachment: fixed;
  font-family: 'Sriracha', Arial;
}

#nav {
  text-align: right;
}

a {
  color: black;
  text-decoration: none;
}
a:hover, a:visited:hover {
  color: gray;
}
a:visited {
  color: black;
}
</style>