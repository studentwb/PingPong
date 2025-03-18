<template>
  <div class="result">
    <p>Wynik: {{ result }}</p>
  </div>
</template>

<script>
  export default {
    data() {
      return {
        result: 0, 
      };
    },
    methods: {
      increaseResult() {
        this.result += 1; 
      },
      resetResult() {
        this.result = 0;
      },
    },
  };
</script>

<style scoped>
  .result {
    position: absolute; 
    top: 20px; 
    left: 50%;
    transform: translateX(-50%);
    font-size: 24px;
    color: white;
  }
</style>
