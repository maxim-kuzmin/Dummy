import type { ApiDataOptions } from '~/utils/shared/api/api.types'
import type { PageData } from '~/utils/shared/page/page.types'

export interface AppNotFoundPageApiModel {
  get(
    dataOptions: AppNotFoundPageApiDataOptions,
  ): Promise<AppNotFoundPageApiData>
}

export type AppNotFoundPageApiDataOptions = ApiDataOptions

export type AppNotFoundPageApiData = PageData
