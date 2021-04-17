<template>
  <div id="app">
    <header>
      <nav class="navbar navbar-expand-sm navbar-toggleable-sm navbar-light bg-white border-bottom box-shadow mb-3">
            <ul class="navbar-nav flex-grow-1">
              <router-link tag="li" :to="{name: 'Cities'}">Cities</router-link>
              <router-link tag="li" :to="{name: 'CityAdd'}">Add City</router-link>
              <router-link tag="li" :to="{name: 'About'}">About</router-link>
            </ul>
      </nav>
    </header>

    <!-- <div id="nav">
      <router-link :to="{name: 'Cities'}">Cities</router-link>|
      <router-link :to="{name: 'CityAdd'}">Add City</router-link>|
      <router-link :to="{name: 'About'}">About</router-link>
    </div> -->
    <hr />
    <router-view class="content" />
  </div>
</template>

<style>
#app {
  font-family: -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto,
    "Helvetica Neue", Arial, "Noto Sans", sans-serif, "Apple Color Emoji",
    "Segoe UI Emoji", "Segoe UI Symbol", "Noto Color Emoji";
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #2c3e50;
}

nav {
  text-align: center;
}
nav ul {
  display: flex;
  flex-direction: row;
  /* justify-content: space-around; */
}

nav ul li {
  padding: 5px 10px;
  margin: 0 10px;
  display: inline-block;
  list-style: none;
  border-radius: 8px;
}
nav ul li:hover {
  background-color: gray;
  color: white;
}

.router-link-exact-active {
  background-color: DarkBlue;
  color: azure;
}

.content {
  margin: 10px 30px;
}

#nav {
  padding: 30px;
}

#nav a {
  font-weight: bold;
  color: #2c3e50;
}

#nav a.router-link-exact-active {
  color: #42b983;
}
</style>
