import axios from 'axios'
import { settingsService } from './SettingsService'
import type { HealthCheck } from '@/types/healthChecks.type'

export async function getHealthChecks(): Promise<HealthCheck> {
  // Get the base URL
  const apiUrl = (await settingsService.getSettings()).apiPath

  // Make the API call with the updated baseURL
  const response = await axios.get<HealthCheck>(apiUrl)
  return response.data
}
