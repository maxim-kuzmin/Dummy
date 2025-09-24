import { HttpParameterNames } from '~/utils/shared/http/http.types'
import { PageParameter } from '~/utils/shared/page/page.types'
import type { AppFakePageStoreData } from './store/app-fake-page-store.types'

export const AppFakePageParameters = {
  id: new PageParameter(HttpParameterNames.id, ''),
  pageNumber: new PageParameter(HttpParameterNames.pageNumber, 1),
}

export interface AppFakePageModel extends AppFakePageStoreData {
  click():void
}
