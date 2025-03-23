<template>
  <div class="game">
    <Result ref="resultRef" />
    <Paddle :startY="200" controlUp="ArrowUp" controlDown="ArrowDown" ref="leftPaddle" class="left-paddle" />
    <Ball @checkCollision="checkCollision" @gameOver="handleGameOver" ref="ball" />
  </div>
</template>

<script>
  import Ball from "./Ball.vue";
  import Paddle from "./Paddle.vue";
  import Result from "./Result.vue";

  export default {
    components: { Paddle, Ball, Result },
    methods: {
      handleGameOver() {
        alert("Gra zakończona! Wynik: " + this.$refs.resultRef.result);
        this.$refs.resultRef.sendResult();
        this.$refs.ball.resetBall(); 
      },

      checkCollision() {
        const ballPosition = this.$refs.ball.$el.getBoundingClientRect();
        const leftPaddle = this.$refs.leftPaddle.$el.getBoundingClientRect();
        const paddleHeight = leftPaddle.height;
        const paddleWidth = leftPaddle.width;

        if (
          ballPosition.left <= leftPaddle.right &&
          ballPosition.right >= leftPaddle.left &&
          ballPosition.top <= leftPaddle.bottom &&
          ballPosition.bottom >= leftPaddle.top
        ) {
          this.$refs.ball.reverseDirection();
          this.$refs.resultRef.increaseResult();
        }
      },
    },
  };
</script>

<style scoped>
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
</style>
