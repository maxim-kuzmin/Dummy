export interface AppFooterComponentStoreData {
  readonly title: Readonly<Ref<string>>
}

export interface AppFooterComponentStoreModel extends AppFooterComponentStoreData {
  load(): void
}
