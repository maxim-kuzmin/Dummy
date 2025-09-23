export interface AppHeaderComponentStoreData {
  readonly indexPageName: globalThis.Ref<string>
  readonly indexPageUrl: globalThis.Ref<string>
}

export interface AppHeaderComponentStoreModel extends AppHeaderComponentStoreData {
  load(): void
}
