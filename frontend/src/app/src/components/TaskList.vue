<template>
    <div>
      <h2 class="mb-3">Task List</h2>
      <ul class="list-group">
        <li v-for="task in tasks" :key="task.id" class="list-group-item d-flex justify-content-between align-items-center">
          <span>
            <strong>{{ task.title }}</strong><br />
            {{ task.description }}
          </span>
  
          <div class="btn-group">
            <button class="btn btn-sm btn-outline-success" @click="toggleCompleted(task)">
              {{ task.completed ? 'Mark Pending' : 'Mark Done' }}
            </button>
            <button class="btn btn-sm btn-outline-danger" @click="deleteTask(task.id)">🗑</button>
          </div>
        </li>
      </ul>
    </div>
  </template>
  
  
  <script setup>
import { ref, onMounted } from 'vue'

const tasks = ref([])

const fetchTasks = async () => {
  const res = await fetch('http://localhost:5019/api/tasks')
  tasks.value = await res.json()
}

const deleteTask = async (id) => {
  const res = await fetch(`http://localhost:5019/api/tasks/${id}`, {
    method: 'DELETE'
  })

  if (res.ok) {
    tasks.value = tasks.value.filter(task => task.id !== id)
  }
}

const toggleCompleted = async (task) => {
  const updated = { ...task, completed: !task.completed }

  const res = await fetch(`http://localhost:5019/api/tasks/${task.id}`, {
    method: 'PUT',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(updated)
  })

  if (res.ok) {
    fetchTasks()
  }
}

onMounted(fetchTasks)
</script>
