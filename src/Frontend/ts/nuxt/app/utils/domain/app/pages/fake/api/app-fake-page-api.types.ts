import type { ApiDataOptions } from '~/utils/shared/api/api.types'
import type { PageData } from '~/utils/shared/page/page.types'

export interface AppFakePageApiDataQuery {
  readonly id: string
  readonly pageNumber: number
}

export interface AppFakePageApiModel {
  get(
    dataQuery: AppFakePageApiDataQuery,
    dataOptions: AppFakePageApiDataOptions,
  ): Promise<AppFakePageApiData>
}

export type AppFakePageApiDataOptions = ApiDataOptions

export type AppFakePageApiData = PageData
