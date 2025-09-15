export interface AppFakePageDataQuery {
  readonly id: string
  readonly pageNumber: number
}

export interface AppFakePageParameters {
  readonly id: globalThis.Ref<string>
  readonly pageNumber: globalThis.Ref<number>
}

export interface AppFakePageParameterNames {
  readonly id: string
  readonly pageNumber: string
}

export interface AppFakePageResources {
  readonly title: string
}

export interface AppFakePagePayload {
  readonly dataQuery: AppFakePageDataQuery
  readonly resources: AppFakePageResources
}

export class AppFakePageData {
  readonly key = ref('')
}
