<template>
  <div class="result">
    <p>Wynik: {{ result }}</p>
  </div>
</template>

<script>
  import axios from 'axios';
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
      async sendResult() {
        
        const resultToSend =  this.result ; 
        console.log('Api przesyła:', resultToSend);
        await axios.post('https://localhost:7026/api/game', resultToSend, {
          headers: {
            'Content-Type': 'application/json' 
          }
        })
          .then((res) => {
            console.log('Wysłano wynik:', res.data);
          })
          .catch((error) => {
            console.error('Błąd podczas wysyłania:', error?.response?.data?.message || error.message);
          });
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
