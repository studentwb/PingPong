<template>
  <div class="paddle" :style="{ top: y + 'px' }"></div>
</template>
<script>
    export default {
      props: {
        startY: Number,
        controlUp: String,
        controlDown: String,
      },
      data() {
        return {
          y: this.startY, // Pozycja paletki
          speed: 5,
          keys: { up: false, down: false },
        };
      },
    mounted() {
      window.addEventListener("keydown", this.handleKeyDown);
      window.addEventListener("keyup", this.handleKeyUp);
      this.movePaddle();
    },
    beforeUnmount() {
      window.removeEventListener("keydown", this.handleKeyDown);
      window.removeEventListener("keyup", this.handleKeyUp);
    },
      methods: {
        handleKeyDown(event) {
          if (event.key === this.controlUp) this.keys.up = true;
          if (event.key === this.controlDown) this.keys.down = true;
        },
        handleKeyUp(event) {
          if (event.key === this.controlUp) this.keys.up = false;
          if (event.key === this.controlDown) this.keys.down = false;
        },
        movePaddle() {
          const animate = () => {
            if (this.keys.up) this.y = Math.max(0, this.y - this.speed);
            if (this.keys.down) this.y = Math.min(window.innerHeight - 100, this.y + this.speed);
            requestAnimationFrame(animate);
          };
          animate();
        },
      },
    };
  </script>

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
