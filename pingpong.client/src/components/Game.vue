<template>
  <div class="game">
    <Paddle :startY="200" controlUp="w" controlDown="s" ref="leftPaddle" class="left-paddle" />
    <Paddle :startY="200" controlUp="ArrowUp" controlDown="ArrowDown" ref="rightPaddle" class="right-paddle" />
    <Ball @checkCollision="checkCollision" ref="ball" />
  </div>
</template>

<script>
  import Ball from "./Ball.vue";
  import Paddle from "./Paddle.vue";

  export default {
    components: { Paddle, Ball },
    methods: {
      checkCollision(ballPosition) {
        const leftPaddle = this.$refs.leftPaddle.$el.getBoundingClientRect();
        const rightPaddle = this.$refs.rightPaddle.$el.getBoundingClientRect();

        // Sprawdzenie kolizji z lewą paletką
        if (
          ballPosition.x <= leftPaddle.right &&
          ballPosition.x + ballPosition.ballsize >= leftPaddle.left &&
          ballPosition.y + ballPosition.ballsize >= leftPaddle.top &&
          ballPosition.y <= leftPaddle.bottom
        ) {
          this.$refs.ball.reverseDirection();
        }

        // Sprawdzenie kolizji z prawą paletką
        if (
          ballPosition.x + ballPosition.ballsize >= rightPaddle.left &&
          ballPosition.x <= rightPaddle.right &&
          ballPosition.y + ballPosition.ballsize >= rightPaddle.top &&
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
    width: 90vw;
    height: 90vh;
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
    background-color: black;
    display: flex;
    justify-content: center;
    align-items: center;
    overflow: hidden;
    border: 5px solid white;
  }

  .left-paddle {
    left: 100px;
  }

  .right-paddle {
    right: 100px;
  }
</style>
