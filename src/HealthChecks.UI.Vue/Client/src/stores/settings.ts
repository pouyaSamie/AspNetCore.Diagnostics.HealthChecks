import type { UISettingsType } from '@/types/uiSettings.type'
import { defineStore } from 'pinia'
import { reactive } from 'vue'
import { fetchSettings } from '@/api/settingsApi'

export const useSettingsStore = defineStore('settings-store', () => {
  const state = reactive({
    settings: {} as UISettingsType
  })

  const initSettings = async (): Promise<void> => {
    state.settings = await fetchSettings()
    console.log('from store:', state.settings)
  }

  return { initSettings, state }
})
