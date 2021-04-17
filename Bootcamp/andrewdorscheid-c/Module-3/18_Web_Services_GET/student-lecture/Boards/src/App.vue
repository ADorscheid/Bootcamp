<template>
  <div class="container">
    <router-view />
  </div>
</template>

<script>
/**************************************************
 * Tasks:
 * 
 * 1. Build and start the application.
 *    Use Postman to take a look at the api server at http://localhost:3000/boards and
 *    http://localhost:3000/boards/39928.
 * 
 * 2. Launch the web page and see how the app works. Take a look at dev tools to try and 
 *    understand what we have so far.
 *    - Look at the code to see how these components are put together.
 *    - Take a look at how the animation works on CardsList.vue
 *    - Examine services\BoardService.js to see how a service is put together.
 * 
 * 3. Build out the Card Detail
 * 
 * 4. Build out the Comments List 
 * 
 * 5. Add a loading animation for the Card Detail
 */
export default {};
</script>

<style>
body {
  font-family: system-ui, -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto,
    'Helvetica Neue', Arial, 'Noto Sans', sans-serif, 'Apple Color Emoji',
    'Segoe UI Emoji', 'Segoe UI Symbol', 'Noto Color Emoji';
}
.container {
  width: 100%;
  max-width: 1100px;
  margin: 0 auto;
}
.loading {
  display: flex;
  justify-content: center;
  align-items: center;
}
</style>
