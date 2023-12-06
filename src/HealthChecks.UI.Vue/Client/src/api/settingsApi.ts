import type { UISettingsType } from '@/types/uiSettings.type'
import { mande } from 'mande'

let baseApiUrl = '/'

if (import.meta.env.VITE_BASE_API_PATH !== '/')
  baseApiUrl = import.meta.env.VITE_BASE_API_PATH as string

const uiSettings = mande(baseApiUrl)
export async function SettingsApi(): Promise<UISettingsType> {
  try {
    const data = await uiSettings.get<UISettingsType>('/ui-settings')
    return data
  } catch (err) {
    console.log(err)
    return {} as UISettingsType
  }
}
