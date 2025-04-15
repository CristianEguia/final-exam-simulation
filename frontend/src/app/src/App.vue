<script setup>
import TaskForm from './components/TaskForm.vue'
import TaskList from './components/TaskList.vue'
</script>

<template>
  <div class="container mt-5">
    <h1 class="mb-4">📝 Task Manager</h1>
    <TaskForm />
    <TaskList />
  </div>
</template>




<style scoped>
.logo {
  height: 6em;
  padding: 1.5em;
  will-change: filter;
  transition: filter 300ms;
}
.logo:hover {
  filter: drop-shadow(0 0 2em #646cffaa);
}
.logo.vue:hover {
  filter: drop-shadow(0 0 2em #42b883aa);
}
</style>
