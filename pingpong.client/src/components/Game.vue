<template>
  <div class="game">
    <Result ref="resultRef" />
    <Paddle :startY="200" controlUp="ArrowUp" controlDown="ArrowDown" ref="leftPaddle" class="left-paddle" />
    <Ball @checkCollision="checkCollision" ref="ball" />
  </div>
</template>

<script>
  import Ball from "./Ball.vue";
  import Paddle from "./Paddle.vue";
  import Result from "./Result.vue";
  export default {
    components: { Paddle, Ball, Result },
    methods: {
      checkCollision(ballPosition) {
        // const leftPaddleY = this.$refs.leftPaddle.y;
        const leftPaddle = this.$refs.leftPaddle.$el.getBoundingClientRect();
        const paddleHeight = 100;
        const paddleWidth = 10;
        //const leftPaddleX = 30;
        const leftPaddleX = leftPaddle.left;    // Pozycja X paletki
        const leftPaddleY = leftPaddle.top;     // Pozycja Y paletki
        if (
          ballPosition.x <= leftPaddleX + paddleWidth &&
          ballPosition.x  >= leftPaddleX &&
          ballPosition.y >= leftPaddleY &&
          ballPosition.y <= leftPaddleY + paddleHeight
        ) {
          console.log("Ball", ballPosition);
          console.log("Paddle X:", leftPaddleX, "Paddle Y:", leftPaddleY);
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

  .right-paddle {
    right: 100px;
  }
</style>

