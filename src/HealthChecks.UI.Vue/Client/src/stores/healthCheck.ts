import { getHealthChecks } from '@/Services/healthchekService'
import { defineStore } from 'pinia'

export const usehealthCheck = defineStore('healthCheck-store', () => {
  async function getHealthCheckReports() {
    return await getHealthChecks()
  }

  return { getHealthCheckReports }
})
