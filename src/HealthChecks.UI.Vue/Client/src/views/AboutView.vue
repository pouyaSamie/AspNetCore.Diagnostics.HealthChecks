<template>
  <div class="about">{{}}</div>
</template>

<script lang="ts" setup>
import { useSettingsStore } from '@/stores/settings'
import type { UISettingsType } from '@/types/uiSettings.type'
import { onMounted, ref } from 'vue'

const settingsStore = useSettingsStore()
const settings = ref<UISettingsType>({} as UISettingsType)
onMounted(async () => {
  try {
    const result = await settingsStore.getSettings()
    console.log(result.data.value)
    settings.value = result.data as unknown as UISettingsType
  } catch (error) {
    console.error('Error fetching settings:', error)
  }
})
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
