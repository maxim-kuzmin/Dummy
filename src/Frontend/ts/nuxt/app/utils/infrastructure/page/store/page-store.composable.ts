import type { PageStoreData } from "./page-store.types"

export const usePageStore = (): globalThis.Ref<PageStoreData> => {
  return useState<PageStoreData>('page-store', () => ({
    pageKey: '',
    pageTitle: ''
  }))
}
