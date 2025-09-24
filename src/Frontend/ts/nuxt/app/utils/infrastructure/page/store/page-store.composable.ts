import type { PageStoreDataQuery, PageStoreModel } from './page-store.types'

const storeKey = 'page'

export const usePageStore = (): PageStoreModel => {
  const pageKey = useState(`${storeKey}.pageKey`, () => '')
  const pageTitle = useState(`${storeKey}.pageTitle`, () => '')

  return {
    pageKey: readonly(pageKey),
    pageTitle: readonly(pageTitle),
    load(data: PageStoreDataQuery): void {
      pageKey.value = data.pageKey
      pageTitle.value = data.pageTitle
    },
  }
}
