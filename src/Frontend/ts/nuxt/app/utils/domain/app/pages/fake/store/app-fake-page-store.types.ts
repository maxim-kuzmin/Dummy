import type { HttpRequestOptions } from '~/utils/shared/http/http.types'
import type { AppFakePageDataQuery } from '../app-fake-page.types'

export interface AppFakePageStoreData {
  readonly clickCount: globalThis.Ref<number>
  readonly pageKey: globalThis.Ref<string>
}

export interface AppFakePageStoreModel extends AppFakePageStoreData {
  readonly clickCount: globalThis.Ref<number>
  readonly pageKey: globalThis.Ref<string>
  incrementClickCount(): void
  load(dataQuery: AppFakePageDataQuery, options: HttpRequestOptions): Promise<void>
}
