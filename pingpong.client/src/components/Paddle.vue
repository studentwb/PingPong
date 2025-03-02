<template>
  <div class="container">
    <div class="paddle" :style="{ top: ballY + 'px', left: ballX + 'px' }"></div>
  </div>
</template>
<script>export default {
    data() {
      return {
        ballX: 100, // Pozycja pozioma
        ballY: 100, // Pozycja pionowa
       // speedX: 2, // Prędkość pozioma
        speedY: 3, // Prędkość pionowa
      };
    },
    mounted() {
      this.movePaddle();
    },
    methods: {
      movePaddle() {
        const animate = () => {
          //this.ballX += this.speedX;
          this.ballY += this.speedY;

          // Odbicia od ścian
          //if (this.ballX <= 0 || this.ballX >= window.innerWidth - 50) {
          //  this.speedX *= -1;
          //}
          if (this.ballY <= 0 || this.ballY >= window.innerHeight - 50) {
            this.speedY *= -1;
          }

          requestAnimationFrame(animate);
        };
        animate();
      },
    },
  };</script>

<style>

  .paddle {
    width: 10px;
    height: 100px;
    background-size: contain;
    border-radius: 0%;
    background-color: red;
    position: absolute;
  }
</style>
