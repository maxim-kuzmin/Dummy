export interface AppMainComponentStoreData {
  readonly title: globalThis.Ref<string>
}

export interface AppMainComponentStoreModel extends AppMainComponentStoreData {
  load(): void
}
