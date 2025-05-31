import { createRouter, createWebHistory } from 'vue-router';
import Login from '../components/LoginPage.vue';
import Game from '../components/Game.vue';
import Register from '../components/RegisterPage.vue';
const routes = [
  { path: '/', redirect: '/login' },
  { path: '/login', component: Login },
  { path: '/game', component: Game },
  { path: '/registerPage', component: Register }
];

const router = createRouter({
  history: createWebHistory(),
  routes
});

export default router;
