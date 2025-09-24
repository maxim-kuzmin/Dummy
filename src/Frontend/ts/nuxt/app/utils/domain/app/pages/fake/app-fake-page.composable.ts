import { useLanguage } from '~/utils/infrastructure/language/language.composable'
import { getAppFakePageApiService } from './api/app-fake-page-api.service'
import { useAppFakePageStore } from './store/app-fake-page-store.composable'
import type { AppFakePageModel } from './app-fake-page.types'

export const useAppFakePage = (): AppFakePageModel => {
  const appFakePageStoreModel = useAppFakePageStore()
  const languageModel = useLanguage()
  const route = useRoute()

  const appFakePageApiService = getAppFakePageApiService()

  watchEffect(async () => {
    const dataQuery = appFakePageApiService.getDataQueryFromRouteLocation(route)
    const locale = languageModel.getCurrentLanguage().code

    await appFakePageStoreModel.load(dataQuery, { locale })
  })

  return {
    get clickCount() {
      return appFakePageStoreModel.clickCount
    },
    get pageKey() {
      return appFakePageStoreModel.pageKey
    },
    click(): void {
      appFakePageStoreModel.incrementClickCount()
    },
  }
}
