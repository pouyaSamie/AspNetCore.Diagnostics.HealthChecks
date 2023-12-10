<template>
  <main>{{ data }}</main>
</template>

<script lang="ts" setup>
import { usehealthCheck } from '@/stores/healthCheck'
import type { HealthCheck } from '@/types/healthChecks.type'
import { onMounted, ref } from 'vue'

const healthCheckStore = usehealthCheck()
const data = ref<HealthCheck>()
onMounted(async () => {
  try {
    const response = await healthCheckStore.getHealthCheckReports()
    data.value = response // Assuming your response has a 'data' property
  } catch (error) {
    console.error('Error fetching health check reports:', error)
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
@/store/healthCheck
