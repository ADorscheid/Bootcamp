<template>
  <div id="main">
    <header>
      <div>Book Reviews</div>
      <nav>
        <!-- TODO: Add router-links to products and about pages. -->
      </nav>
    </header>
    <main class="main">
      <!-- 01: Add the router-view to display the current view -->
    </main>
    <footer>&copy; Copyright 2021, Dummies for Book Reviews</footer>
  </div>
</template>

<script>
/******************************************
 * Notes:
 *  1. There is a new ProductsList component, which simply lists all the products
 *      in $store in a table
 *  2. Vue Router has been added to this project. Note the files and folders that
 *      were added or modified.
 *
 * Tasks
 */
/* TODO 01. Create a Products view which will be our home page (Products.vue)
 *      - Add a heading and the ProductsList component (ProductsList.vue)
 *      - Add it as the default route (/) (index.js)
 *      - Add the router-view (app.vue)
 */
/* TODO 02. Create a ProductDetail view which displays a detailed view of the product (basically
 *      our reviews page from previous days)
 *      - Create the page (ProductDetail.vue) [Snippets.txt]
 *      - Add a route so that this page can be addressed (dynamic routing) [/product/:id]
 *      - Create a data property to hold the current productId (default to 0)
 *      - Add the created() function to set the productId to the $route parameter
 *      - Update the computed property to get the product using the productId
 *      - Test the route using ids (maybe use a v-if for product?)
 */
/* TODO 03. Add router-link(s) in the ProductsList component to each of the products
 *          in the list, binding to the "to" attribute/prop
 */
/* TODO 04. Add a router-link on ProductDetail.vue to go "back to Products list",
 *          the home page
 */
/* TODO 05. Make Add Review available once a user is looking at the ProductDetail view
 *      - Add a view for AddReviewPage which hosts the AddReview component
 *      - Add a route for AddReviewPage. /product/:id/add-review
 *      - add a router-link to the ProductDetail view to go to the Add Review view.
 *      - Update AddReview to go back to the product page after the review has been added
 *        (or canceled)
 */
 /* TODO 06: Hook up the nav bar
 *      - Add an about page
 *      - Add router-links to products and about pages
 *      - Add routerlinkactiveexact styling
 */
export default {};
</script>

<style>
body {
  height: 100vh;
}
#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
}

#main {
  max-width: 800px;
  margin: 0 auto 0 auto;
  text-align: center;
  display: grid;
  grid-template-rows: 60px 1fr 20px;
  min-height: 100%;
}

header {
  background-color: lightcyan;
  border-bottom: solid 2px blue;
  /* padding-top: 30px; */
}

header > div {
  font-size: 1.2rem;
  font-weight: bold;
}

header > nav {
  display: flex;
  flex-direction: row;
  justify-content: center;
}

header > nav > a {
  display: inline-block;
  padding: 3px 10px;
}

main.main {
  margin: 0 0;
  height: 100%;
}

footer {
  background-color: lightcyan;
  border-top: solid 2px blue;
  font-size: 0.8rem;
  font-weight: lighter;
}

.selectedFilter {
  background-color: lightyellow;
}
</style>
