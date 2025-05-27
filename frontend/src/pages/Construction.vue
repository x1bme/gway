<template>
 <q-page class="under-construction">
    <div class="text-center q-py-xl">
      <h1 class="text-h2">Coming Soon</h1>
      <p class="text-body1">Still building this part...</p>
      <q-btn icon="home" label="Loom Home" color="primary" size="lg" to="/" />
    </div>
 </q-page>
</template>

<script>
export default {
 // Component logic goes here
};
</script>

<style scoped>
.under-construction {
 display: flex;
 justify-content: center;
 align-items: center;
 height: 100vh;
 background-color: #f5f5f7; /* Light grey background */
 text-align: center;
}

h1 {
 font-size: 3em;
 color: #333; /* Darker text for contrast */
 margin-bottom: 20px; /* Space below the title */
}

p {
 font-size: 1.2em;
 color: #666; /* Softer text color */
 margin-bottom: 30px; /* Space below the text */
}

q-btn {
 width: 200px; /* Fixed width for consistency */
}
</style>
