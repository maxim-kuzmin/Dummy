export class AppHeaderComponentData {
  readonly indexPageName = ref('')
  readonly indexPageUrl = ref('')
}

export type AppHeaderComponentService = AppHeaderComponentData & {
  click(): void;
}
