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
          if (this.y <= 0 || this.y >= window.innerHeight - 20) {
            this.speedY *= -1;
          }

          // Odbicie od paletek
          this.$emit("checkCollision", { x: this.x, y: this.y });

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
    width: 100px;
    height: 100px;
    background-image: url('/src/components/icons/ball.png');
    background-size: contain;
    border-radius: 50%;
    position: absolute;
  }
</style>
