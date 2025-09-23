import type { HttpRequestOptions } from '~/utils/shared/http/http.types'

export interface AppNotFoundPageStoreModel {
  load(options: HttpRequestOptions): Promise<void>
}
