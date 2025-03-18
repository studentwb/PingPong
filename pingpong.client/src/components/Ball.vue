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
        animationFrameId: null, 
        gameOver: false, 
      };
    },
    mounted() {
      this.moveBall();
    },
    beforeUnmount() {
      cancelAnimationFrame(this.animationFrameId);
    },
    methods: {
      moveBall() {
        const animate = () => {
          if (this.gameOver) return; 

          this.x += this.speedX;
          this.y += this.speedY;

          if (this.y <= 0 || this.y >=0.9* window.innerHeight - this.ballSize) {
            this.speedY *= -1;
          }
          if (this.x >=0.9* window.innerWidth - this.ballSize) {
            this.speedX *= -1;
          }
          if (this.x <= 0) {
            this.$emit("gameOver");
            this.gameOver = true; 
            return;
          }
          this.$emit("checkCollision", {
            x: this.x,
            y: this.y,
            ballSize: this.ballSize,
          });

          this.animationFrameId = requestAnimationFrame(animate);
        };
        animate();
      },

      reverseDirection() {
        this.speedX *= -1;
        this.x += this.speedX * 2; 
      },

      resetBall() {
        this.x = window.innerWidth / 2;
        this.y = window.innerHeight / 2;
        this.speedX = (Math.random() > 0.5 ? 1 : -1) * 5;
        this.speedY = (Math.random() > 0.5 ? 1 : -1) * 3;
        this.gameOver = false;
        this.moveBall(); 
      },
    },
  };
</script>

<style scoped>
  .ball {
    width: 50px;
    height: 50px;
    background-image: url("/src/components/icons/ball.png");
    background-size: contain;
    border-radius: 50%;
    position: absolute;
  }
</style>
