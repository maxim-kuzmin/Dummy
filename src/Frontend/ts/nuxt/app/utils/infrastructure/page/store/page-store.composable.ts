import type { PageStoreModel } from "./page-store.types"

const storeKey = 'page'

export const usePageStore = (): PageStoreModel => {
  const pageKey = useState(`${storeKey}.pageKey`, () => '')
  const pageTitle = useState(`${storeKey}.pageTitle`, () => '')

  return {
    pageKey,
    pageTitle
  }
}
