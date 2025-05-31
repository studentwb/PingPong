<script setup lang="ts">
  import Game from './components/Game.vue'
  import Ball from './components/Ball.vue'
  import Result from './components/Result.vue'
  import LoginView from './components/LoginPage.vue'
  import Register from './components/RegisterPage.vue'
</script>

<template>
  <router-view />
</template>
<style>
  html, body, #app {
    margin: 0;
    padding: 0;
    height: 100%;
    background: linear-gradient(black, indigo);
    font-family: 'Segoe UI', sans-serif;
  }
</style>

