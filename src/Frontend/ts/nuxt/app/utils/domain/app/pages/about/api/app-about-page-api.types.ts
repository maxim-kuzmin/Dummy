import type { ApiDataOptions } from '~/utils/shared/api/api.types'
import type { PageData } from '~/utils/shared/page/page.types'

export interface AppAboutPageApiModel {
  get(
    dataOptions: AppAboutPageApiDataOptions,
  ): Promise<AppAboutPageApiData>
}

export type AppAboutPageApiDataOptions = ApiDataOptions

export type AppAboutPageApiData = PageData
