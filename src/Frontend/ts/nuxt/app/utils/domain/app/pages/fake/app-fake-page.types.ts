import { HttpParameterNames } from '~/utils/shared/http/http.types'
import { PageParameter, type PageData } from '~/utils/shared/page/page.types'
import type { AppFakePageStoreData } from './store/app-fake-page-store.types'

export interface AppFakePageDataQuery {
  readonly id: string
  readonly pageNumber: number
}

export const AppFakePageParameters = {
  id: new PageParameter(HttpParameterNames.id, ''),
  pageNumber: new PageParameter(HttpParameterNames.pageNumber, 1),
}

export type AppFakePageData = PageData

export interface AppFakePageModel extends AppFakePageStoreData {
  click():void
}
