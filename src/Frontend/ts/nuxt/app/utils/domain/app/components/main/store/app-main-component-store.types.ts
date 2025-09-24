export interface AppMainComponentStoreData {
  readonly title: Readonly<Ref<string>>
}

export interface AppMainComponentStoreModel extends AppMainComponentStoreData {
  load(): void
}
