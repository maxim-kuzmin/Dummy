export interface AppHeaderComponentStoreData {
  readonly indexPageName: Readonly<Ref<string>>
  readonly indexPageUrl: Readonly<Ref<string>>
}

export interface AppHeaderComponentStoreModel extends AppHeaderComponentStoreData {
  load(): void
}
