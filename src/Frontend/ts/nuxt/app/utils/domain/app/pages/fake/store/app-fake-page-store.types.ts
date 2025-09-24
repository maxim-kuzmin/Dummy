import type {
  AppFakePageApiDataOptions,
  AppFakePageApiDataQuery,
} from '../api/app-fake-page-api.types'

export interface AppFakePageStoreData {
  readonly clickCount: Readonly<Ref<number>>
  readonly pageKey: Readonly<Ref<string>>
}

export interface AppFakePageStoreModel extends AppFakePageStoreData {
  incrementClickCount(): void
  load(
    dataQuery: AppFakePageApiDataQuery,
    dataOptions: AppFakePageApiDataOptions,
  ): Promise<void>
}
