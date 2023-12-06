<template>
  <div class="about">{{ settings }}</div>
</template>

<script lang="ts" setup>
import { useSettingsStore } from '@/stores/settings'
import { computed } from 'vue'

const settingsStore = useSettingsStore()
const settings = computed(() => settingsStore.state.settings)
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
