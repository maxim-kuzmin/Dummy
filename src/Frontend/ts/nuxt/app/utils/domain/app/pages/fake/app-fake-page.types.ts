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

export class AppFakePageData {
  readonly key = ref('')
  readonly clickCount = ref(0)
}

export type AppFakePageModel = AppFakePageData & {
  click(): void
}
