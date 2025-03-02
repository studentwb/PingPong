<template>
    <div class="ball" :style="{ top: y + 'px', left: x + 'px' }"></div>
</template>

<script>
  export default {
    data() {
      return {
        x: window.innerWidth / 2,
        y: window.innerHeight / 2,
        speedX: 5,
        speedY: 3,
        ballSize: 50,
      };
    },
    mounted() {
      this.moveBall();
    },
    methods: {
      moveBall() {
        const animate = () => {
          this.x += this.speedX;
          this.y += this.speedY;

          // Odbicie od góry i dołu
          if (this.y <= 0 || this.y >= 0.9*window.innerHeight - this.ballSize) {
            this.speedY *= -1;
          }
          if (this.x <= 0 || this.x >= 0.9*window.innerWidth - this.ballSize) {
          this.speedX *= -1;
          }
          // Odbicie od paletek
          this.$emit("checkCollision", { x: this.x, y: this.y, size: this.ballSize });

          requestAnimationFrame(animate);
        };
        animate();
      },
      reverseDirection() {
        this.speedX *= -1; // Odbicie od paletki
      },
    },
  };
</script>

<style>
  .container {
    width: 100vw;
    height: 100vh;
    position: relative;
    overflow: hidden;
    background-color: black
  }

  .ball {
    width: 50px;
    height: 50px;
    background-image: url('/src/components/icons/ball.png');
    background-size: contain;
    border-radius: 50%;
    position: absolute;
  }
</style>
