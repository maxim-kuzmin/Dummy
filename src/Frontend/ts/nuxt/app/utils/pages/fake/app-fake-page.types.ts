export interface AppFakePageParameters {
  readonly id: globalThis.Ref<string>
}

export interface AppFakePageDataQuery {
  readonly id: string
}

export interface AppFakePageDataLoadCommand extends AppFakePageDataQuery {
  readonly title: string
}

export class AppFakePageData {
  readonly key = ref('')
}
