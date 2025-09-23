import type { HttpRequestOptions } from '~/utils/shared/http/http.types'

export interface AppAboutPageStoreModel {
  load(options: HttpRequestOptions): Promise<void>
}
