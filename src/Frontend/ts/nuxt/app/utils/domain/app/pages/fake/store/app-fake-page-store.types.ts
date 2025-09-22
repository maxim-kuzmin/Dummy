import type { AppFakePageDataQuery } from '../app-fake-page.types'

export interface AppFakePageStoreModel {
  readonly clickCount: globalThis.Ref<number>
  readonly pageKey: globalThis.Ref<string>
  click(): void
  load(dataQuery: AppFakePageDataQuery): Promise<void>
}
