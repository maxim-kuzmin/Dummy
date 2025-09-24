import type { ApiDataOptions } from '~/utils/shared/api/api.types'
import type { PageData } from '~/utils/shared/page/page.types'

export interface AppIndexPageApiModel {
  get(
    dataOptions: AppIndexPageApiDataOptions,
  ): Promise<AppIndexPageApiData>
}

export type AppIndexPageApiDataOptions = ApiDataOptions

export type AppIndexPageApiData = PageData
