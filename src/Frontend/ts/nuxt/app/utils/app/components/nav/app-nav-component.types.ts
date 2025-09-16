export interface AppNavComponentPayload {
  readonly aboutPageUrl: string
  readonly fakePageUrl1: string
  readonly fakePageUrl1pn2: string
  readonly fakePageUrl2: string
}

export class AppNavComponentData {
  readonly aboutPageUrl = ref('')
  readonly fakePageUrl1 = ref('')
  readonly fakePageUrl1pn2 = ref('')
  readonly fakePageUrl2 = ref('')
}
