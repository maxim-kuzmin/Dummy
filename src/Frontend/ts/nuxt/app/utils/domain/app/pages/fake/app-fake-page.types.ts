import { AppParameterNames } from '~/utils/domain/app/app.types'
import {
  PageParameter,
  type PageDataQuery,
} from '~/utils/shared/page/page.types'
import type { AppFakePageStoreModel } from './store/app-fake-page-store.types'
import { defaultLanguage } from '~/utils/shared/language/language.types'

export interface AppFakePageDataQuery extends PageDataQuery {
  readonly id: string
  readonly pageNumber: number
}

export const AppFakePageParameters = {
  id: new PageParameter(AppParameterNames.id, ''),
  locale: new PageParameter(AppParameterNames.locale, defaultLanguage.code),
  pageNumber: new PageParameter(AppParameterNames.pageNumber, 1),
}

export type AppFakePageModel = AppFakePageStoreModel
