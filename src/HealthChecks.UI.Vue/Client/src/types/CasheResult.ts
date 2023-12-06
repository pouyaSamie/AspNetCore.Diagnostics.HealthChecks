import type { Ref } from "vue"

export interface CasheResult<T> {
  data:  Ref<T | undefined>
  error: Ref<Error | undefined>
  isLoading: Ref<boolean>
  isReady: Ref<boolean>
}