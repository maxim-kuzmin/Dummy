import type { HttpRequestOptions } from '~/utils/shared/http/http.types'

export interface AppIndexPageStoreModel {
  load(options: HttpRequestOptions): Promise<void>
}
