export interface AppHeaderComponentStoreModel {
  readonly indexPageName: Readonly<Ref<string>>
  readonly indexPageUrl: Readonly<Ref<string>>
  load(): void
}
