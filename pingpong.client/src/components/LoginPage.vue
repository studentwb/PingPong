<template>
  <div>
    <h2>Logowanie</h2>
    <input v-model="username" placeholder="login" />
    <button @click="login">Zaloguj</button>
  </div>
</template>

<script lang="ts" setup>
  import { ref } from 'vue';
  import { useRouter } from 'vue-router';

  const username = ref('');
  const router = useRouter();

  function login() {
    if (username.value.trim()) {
      localStorage.setItem('user', username.value);
      router.push('/game'); 
    }
  }
</script>
