import type {
  AppFakePageApiDataOptions,
  AppFakePageApiDataQuery,
} from '../api/app-fake-page-api.types'

export interface AppFakePageStoreModel {
  readonly clickCount: Readonly<Ref<number>>
  readonly pageKey: Readonly<Ref<string>>
  incrementClickCount(): void
  load(
    dataQuery: AppFakePageApiDataQuery,
    dataOptions: AppFakePageApiDataOptions,
  ): Promise<void>
}
