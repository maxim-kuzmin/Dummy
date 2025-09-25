export interface AppMainComponentStoreModel {
  readonly title: Readonly<Ref<string>>
  load(): void
}
