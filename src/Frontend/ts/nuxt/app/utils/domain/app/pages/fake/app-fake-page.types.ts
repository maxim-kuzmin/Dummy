import { AppParameterNames } from '~/utils/domain/app/app.types'
import { PageParameter } from '~/utils/shared/page/page.types'

export interface AppFakePageDataQuery {
  readonly id: string
  readonly pageNumber: number
}

export const AppFakePageParameters = {
  id: new PageParameter(AppParameterNames.id, ''),
  pageNumber: new PageParameter(AppParameterNames.pageNumber, 1),
}

export interface AppFakePageModel {
  readonly clickCount: globalThis.Ref<number>
  readonly pageKey: globalThis.Ref<string>
  click(): void
}
