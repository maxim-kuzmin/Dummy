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

export class AppFakePageData {
  readonly key = ref('')
  readonly clickCount = ref(0)
}

export type AppFakePageModel = AppFakePageData & {
  click(): void;
}
