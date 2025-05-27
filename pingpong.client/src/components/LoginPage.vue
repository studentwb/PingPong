<template>
  <div class="login-container">
    <div class="login-card">
      <h2>Zaloguj się</h2>
      <input v-model="username"
             placeholder="User name"
             class="input" />
      <div class="password-wrapper">
        <input :type="showPassword ? 'text' : 'password'"
               class="input password-input"
               v-model="password"
               placeholder="Hasło" />
        <button type="button" class="show-password-button" @click="toggleShow">
          <i class="fas" :class="showPassword ? 'fa-eye-slash' : 'fa-eye'"></i>
        </button>
      </div>
      <button @click="login" class="btn">Login</button>
      <button @click="register" class="btn">Register</button>
    </div>
  </div>
</template>

<script setup lang="ts">
  import { ref } from 'vue';
  import { useRouter } from 'vue-router';

  const username = ref('');
  const password = ref('')
  const showPassword = ref(false)
  const router = useRouter();

  function login() {
    if (username.value.trim()) {
      localStorage.setItem('user', username.value);
      router.push('/game'); 
    }
  }
  function register() {
      router.push('/registerPage');
    
  }
  function toggleShow() {
    showPassword.value = !showPassword.value
  }
</script>

<style scoped>
  .login-container {
    display: flex;
    justify-content: center;
    align-items: center;
    background: linear-gradient(black, indigo);
    height: 100vh;
    width: 100vw;
  }

  .login-card {
    background-color: #1a1a1a;
    padding: 2rem 3rem;
    border-radius: 12px;
    box-shadow: 0 0 20px rgba(255, 255, 255, 0.05);
    display: flex;
    flex-direction: column;
    width: 100%;
    max-width: 400px;
  }

  h2 {
    color: #fff;
    margin-bottom: 1.5rem;
    text-align: center;
  }

  .input {
    padding: 0.8rem 1rem;
    margin-bottom: 1rem;
    border: none;
    border-radius: 8px;
    background-color: #2c2c2c;
    color: #fff;
    font-size: 1rem;
    outline: none;
    

  }

    .input::placeholder {
      color: #888;
    }

  .btn {
    padding: 0.8rem;
    background-color: #4f46e5;
    color: #fff;
    border: none;
    border-radius: 8px;
    font-weight: bold;
    cursor: pointer;
    transition: background-color 0.3s ease;
    margin: 10px;
  }

    .btn:hover {
      background-color: #6366f1;
    }
  .password-wrapper {
    position: relative;
    display: flex;
    align-items: center;
    width: 100%;
  }

  .password-input {
    width: 100%;
    padding-right: 40px; 
    height: 40px;
    font-size: 1rem;
    border-radius: 8px;
    border: 1px solid #ccc;
  }

  .show-password-button {
    position: absolute;
    right: 10px;
    background: transparent;
    border: none;
    cursor: pointer;
    color: #555;
    font-size: 1.1rem;
    transition: color 0.2s;
    margin-top: -15px;
  }

    .show-password-button:hover {
      color: #000;
    }
</style>
