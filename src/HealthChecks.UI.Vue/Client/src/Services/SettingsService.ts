import type { UISettingsType } from '@/types/uiSettings.type'
import axios from 'axios'
let cachedSettings: UISettingsType;
export async function fetchSettings(): Promise<UISettingsType> {
  try {
    const response = await axios.get<UISettingsType>('/ui-settings')
    return response.data
  } catch (error) {
    console.error('Error fetching data:', error)
    throw error
  }
}

export const settingsService = {
  getSettings: async () => {
    if (cachedSettings) {
      return cachedSettings
    }

    // Fetch settings from the server
    cachedSettings = await fetchSettings()
    return cachedSettings
  }
}
