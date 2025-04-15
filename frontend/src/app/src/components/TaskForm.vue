<template>
    <div class="card mb-4">
      <div class="card-body">
        <h2 class="card-title mb-3">Add Task</h2>
        <form @submit.prevent="submitTask">
          <div class="mb-3">
            <label for="title" class="form-label">Title</label>
            <input type="text" id="title" v-model="task.title" class="form-control" required />
          </div>
          <div class="mb-3">
            <label for="description" class="form-label">Description</label>
            <textarea id="description" v-model="task.description" class="form-control"></textarea>
          </div>
          <div class="form-check mb-3">
            <input type="checkbox" id="completed" v-model="task.completed" class="form-check-input" />
            <label for="completed" class="form-check-label">Completed</label>
          </div>
          <button type="submit" class="btn btn-primary">Create Task</button>
        </form>
      </div>
    </div>
  </template>
  
  <script setup>
  import { reactive } from 'vue'
  
  const task = reactive({
    title: '',
    description: '',
    completed: false
  })
  
  const submitTask = async () => {
    const res = await fetch('http://localhost:5019/api/tasks', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(task)
    })
  
    if (res.ok) {
      alert('Task created!')
      task.title = ''
      task.description = ''
      task.completed = false
    } else {
      alert('Error creating task')
    }
  }
  </script>
  