<template>
  <div class="game">
    <Paddle :startY="200" controlUp="w" controlDown="s" ref="leftPaddle" class="left-paddle" />
    <Paddle :startY="200" controlUp="ArrowUp" controlDown="ArrowDown" ref="rightPaddle" class="right-paddle" />
    <Ball @checkCollision="checkCollision" ref="ball" />
  </div>
</template>

<script>
  import Ball from './Ball.vue'
  import Paddle from './Paddle.vue'

export default {
  components: { Paddle, Ball },
  methods: {
    checkCollision(ballPosition) {
      const leftPaddle = this.$refs.leftPaddle.$el.getBoundingClientRect();
      const rightPaddle = this.$refs.rightPaddle.$el.getBoundingClientRect();

      // Sprawdzenie kolizji z lewą paletką
      if (
        ballPosition.x <= leftPaddle.right &&
        ballPosition.y >= leftPaddle.top &&
        ballPosition.y <= leftPaddle.bottom
      ) {
        this.$refs.ball.reverseDirection();
      }

      // Sprawdzenie kolizji z prawą paletką
      if (
        ballPosition.x >= rightPaddle.left - 20 &&
        ballPosition.y >= rightPaddle.top &&
        ballPosition.y <= rightPaddle.bottom
      ) {
        this.$refs.ball.reverseDirection();
      }
    },
  },
};
</script>

<style>
  .game {
    width: 80vw; /* Plansza zajmuje 80% szerokości okna */
    height: 90vh; /* Plansza zajmuje 90% wysokości okna */
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%); /* Centrowanie */
    background-color: black;
    display: flex;
    justify-content: center;
    align-items: center;
    overflow: hidden;
    border: 5px solid white; /* Dodanie ramki */
  }

  .left-paddle {
    left: 30px;
  }

  .right-paddle {
    right: 30px;
  }
</style>
