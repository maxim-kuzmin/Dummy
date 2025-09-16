export interface AppHeaderComponentPayload {
  readonly indexPageName: string
  readonly indexPageUrl: string
}

export class AppHeaderComponentData {
  readonly indexPageName = ref('')
  readonly indexPageUrl = ref('')
}
