import type { AppAboutPageApiDataOptions } from '../api/app-about-page-api.types'

export interface AppAboutPageStoreModel {
  load(dataOptions: AppAboutPageApiDataOptions): Promise<void>
}
