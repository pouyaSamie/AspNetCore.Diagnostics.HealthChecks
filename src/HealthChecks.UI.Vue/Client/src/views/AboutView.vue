<template>
  <div class="about">
    <h1>{{ settings }}</h1>
  </div>
</template>

<script lang="ts" setup>
import { ref } from 'vue'

const settings = ref(null)
fetch('https://localhost:44318/ui-settings')
  .then((response) => response.json())
  .then((data) => (settings.value = data))
</script>
<style>
@media (min-width: 1024px) {
  .about {
    min-height: 100vh;
    display: flex;
    align-items: center;
  }
}
</style>
