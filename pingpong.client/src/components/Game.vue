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
        const leftPaddleY = this.$refs.leftPaddle.y;
        const rightPaddleY = this.$refs.rightPaddle.y;
        const paddleHeight = 100;
        const paddleWidth = 10;
        const leftPaddleX = 30;
        const rightPaddleX = window.innerWidth - 40;
        //do poprawy logika biznesowa tych if-ów
          //a tak to działa 
        // Sprawdzenie kolizji z lewą paletką
        if (
          ballPosition.x <= leftPaddleX + paddleWidth &&
          ballPosition.x + ballPosition.ballSize >= leftPaddleX &&
          ballPosition.y + ballPosition.ballSize >= leftPaddleY &&
          ballPosition.y <= leftPaddleY + paddleHeight
        ) {
          console.log("ball:", ballPosition);
          console.log("left:", { x: leftPaddleX, y: leftPaddleY });
          this.$refs.ball.reverseDirection();
        }

        // Sprawdzenie kolizji z prawą paletką
        if (
          ballPosition.x + ballPosition.ballSize >= rightPaddleX &&
          ballPosition.x <= rightPaddleX + paddleWidth &&
          ballPosition.y + ballPosition.ballSize >= rightPaddle.y &&
          ballPosition.y <= rightPaddle.y + paddleHeight
        ) {
          console.log("ball:", ballPosition);
          console.log("Prawa paletka:", { x: rightPaddleX, y: rightPaddleY });
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
