import { HttpParameterNames } from '~/utils/shared/http/http.types'
import { PageParameter } from '~/utils/shared/page/page.types'
import type { AppFakePageStoreModel } from './store/app-fake-page-store.types'

export interface AppFakePageDataQuery {
  readonly id: string
  readonly pageNumber: number
}

export const AppFakePageParameters = {
  id: new PageParameter(HttpParameterNames.id, ''),
  pageNumber: new PageParameter(HttpParameterNames.pageNumber, 1),
}

export type AppFakePageModel = AppFakePageStoreModel
