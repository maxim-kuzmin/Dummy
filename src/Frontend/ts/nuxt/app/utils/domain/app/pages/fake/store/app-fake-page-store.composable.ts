import type { AppFakePageStoreModel } from './app-fake-page-store.types'

const storeKey = 'app-fake-page'

export const useAppFakePageStore = (): AppFakePageStoreModel => {
  const clickCount = useState(`${storeKey}.clickCount`, () => 0)
  const pageKey = useState(`${storeKey}.pageKey`, () => '')

  return {
    clickCount,
    pageKey,
    click():void {
      clickCount.value++
    },
    load():void {

    },
  }
}
