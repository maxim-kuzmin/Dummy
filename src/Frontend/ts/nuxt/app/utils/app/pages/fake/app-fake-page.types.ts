import { PageParameter } from '~/utils/shared/page/page.types'

export interface AppFakePageDataQuery {
  readonly id: string
  readonly pageNumber: number
}

export class AppFakePageParameters {
  readonly id = new PageParameter('id', '')
  readonly pageNumber = new PageParameter('pn', 1)
}

export class AppFakePageData {
  readonly key = ref('')
  readonly clickCount = ref(0)
}

export type AppFakePageModel = AppFakePageData & {
  click(): void
}
