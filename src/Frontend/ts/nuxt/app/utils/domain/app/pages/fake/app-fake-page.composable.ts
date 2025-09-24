import { useAppFakePageStore } from './store/app-fake-page-store.composable'
import type { AppFakePageModel } from './app-fake-page.types'

export const useAppFakePage = (): AppFakePageModel => {
  const appFakePageStoreModel = useAppFakePageStore()

  return {
    ...appFakePageStoreModel,
    click(): void {
      appFakePageStoreModel.incrementClickCount()
    },
  }
}
