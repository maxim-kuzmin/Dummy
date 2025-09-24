import { usePageStore } from '~/utils/infrastructure/page/store/page-store.composable'
import { useAppAboutPageApi } from '../api/app-about-page-api.composable'
import type { AppAboutPageApiDataOptions } from '../api/app-about-page-api.types'
import { getAppAboutPageService } from '../app-about-page.service'
import type { AppAboutPageStoreModel } from './app-about-page-store.types'

//const storeKey = 'app-about-page'

export const useAppAboutPageStore = (): AppAboutPageStoreModel => {
  const appAboutPageApiModel = useAppAboutPageApi()
  const pageStoreModel = usePageStore()

  const appAboutPageService = getAppAboutPageService()

  return {
    async load(dataOptions: AppAboutPageApiDataOptions): Promise<void> {
      const data = await appAboutPageApiModel.get(dataOptions)

      pageStoreModel.load({
        pageKey: appAboutPageService.createPageKey(dataOptions.locale),
        pageTitle: data.pageTitle,
      })
    },
  }
}
