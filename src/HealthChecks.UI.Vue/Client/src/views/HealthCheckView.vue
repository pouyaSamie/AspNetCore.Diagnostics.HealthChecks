<template>
  <main></main>
</template>

<script lang="ts" setup>
import { useSettingsStore } from '@/stores/settings';
import { computed } from 'vue';

const settingStore = useSettingsStore()
const settings = computed(() => settingStore.state.settings)

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
