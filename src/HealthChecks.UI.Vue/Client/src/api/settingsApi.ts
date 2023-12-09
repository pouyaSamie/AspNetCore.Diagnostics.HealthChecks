import type { UISettingsType } from '@/types/uiSettings.type'
import axios from 'axios'

export async function fetchSettings(): Promise<UISettingsType> {
  try {
    const response = await axios.get<UISettingsType>('/ui-settings')
    return response.data
  } catch (error) {
    console.error('Error fetching data:', error)
    throw error
  }
}
