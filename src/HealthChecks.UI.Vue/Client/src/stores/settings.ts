import type { UISettingsType } from '@/types/uiSettings.type'
import { defineStore } from 'pinia'
import { ref } from 'vue'
import { SettingsApi } from '@/api/settingsApi'
import { useCachedRequest } from './useCachedRequest'
import type { CasheResult } from '@/types/CasheResult'

export const useSettingsStore = defineStore('settings-store', () => {
  function getSettings(): CasheResult<UISettingsType> {
    const key = ref('settings')
    return useCachedRequest<UISettingsType, string>(key, async () => {
      const x = SettingsApi()
      console.log(x)
      return x
    })
  }
  return { getSettings }
})
