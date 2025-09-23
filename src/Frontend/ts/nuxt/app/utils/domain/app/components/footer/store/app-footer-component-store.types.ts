export interface AppFooterComponentStoreData {
  readonly title: globalThis.Ref<string>
}

export interface AppFooterComponentStoreModel extends AppFooterComponentStoreData {
  load(): void
}
