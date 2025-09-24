import type { AppNotFoundPageApiDataOptions } from '../api/app-not-found-page-api.types'

export interface AppNotFoundPageStoreModel {
  load(dataOptions: AppNotFoundPageApiDataOptions): Promise<void>
}
