<template>
  <div class="result">
    <p>Wynik: {{ result }}</p>
  </div>
</template>

<script>
  export default {
    data() {
      return {
        result: 0, // Naprawiony błąd: użycie ":" zamiast "="
      };
    },
    methods: {
      increaseResult() {
        this.result += 1; // Poprawny dostęp do "this"
      },
    },
  };
</script>

<style scoped>
  .result {
    position: absolute; /* Umieszczenie na górze */
    top: 20px; /* Odstęp od góry */
    left: 50%;
    transform: translateX(-50%);
    font-size: 24px;
    color: white;
  }
</style>
