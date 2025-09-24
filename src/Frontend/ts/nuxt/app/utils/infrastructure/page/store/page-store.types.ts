export interface PageStoreDataQuery {
  pageKey: string
  pageTitle: string
}

export interface PageStoreModel {
  pageKey: Readonly<Ref<string>>
  pageTitle: Readonly<Ref<string>>
  load(data: PageStoreDataQuery): void
}
