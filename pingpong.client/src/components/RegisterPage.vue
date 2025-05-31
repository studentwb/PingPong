<template>
  <div class="register-container">
    
    <form @submit.prevent="handleRegister">
      <h2>Register</h2>
      <input v-model="username" placeholder="Username" required />
      <input v-model="email" type="email" placeholder="Email" required />
      <input v-model="password" type="password" placeholder="Password" required />
      <input v-model="confirmPassword" type="password" placeholder="Confirm Password" required />

      <p v-if="error" class="error">{{ error }}</p>

      <button type="submit">Register</button>
    </form>
  </div>
</template>

<script setup lang="ts">
  import { ref } from 'vue';
  import { useRouter } from 'vue-router';

  const username = ref('');
  const email = ref('');
  const password = ref('');
  const confirmPassword = ref('');
  const error = ref('');

  const router = useRouter();

  const handleRegister = () => {
    if (password.value !== confirmPassword.value) {
      error.value = "Passwords do not matc!.";
      return;
    }

    console.log('Registering:', { username: username.value, email: email.value });
    error.value = '';
    router.push('/login'); 
  };
</script>

<style scoped>
  .register-container {
    display: flex;
    justify-content: center;
    align-items: center;
    background: linear-gradient(black, indigo);
    height: 100vh;
    width: 100vw;
  }

    .register-container h2 {
      text-align: center;
      margin-bottom: 1rem;
    }

  form {
    display: flex;
    flex-direction: column;
    gap: 1rem;
  }

  input {
    padding: 0.75rem;
    border: 1px solid #ccc;
    border-radius: 8px;
    font-size: 1rem;
  }

  button {
    padding: 0.75rem;
    background-color: #42b983;
    color: white;
    border: none;
    border-radius: 8px;
    font-size: 1rem;
    cursor: pointer;
    transition: background-color 0.2s ease;
  }

    button:hover {
      background-color: #369f72;
    }

  .error {
    color: red;
    font-size: 0.9rem;
    text-align: center;
  }
</style>
