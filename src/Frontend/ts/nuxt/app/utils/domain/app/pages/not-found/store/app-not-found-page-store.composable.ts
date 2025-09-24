import { usePageStore } from '~/utils/infrastructure/page/store/page-store.composable'
import { useAppNotFoundPageApi } from '../api/app-not-found-page-api.composable'
import type { AppNotFoundPageApiDataOptions } from '../api/app-not-found-page-api.types'
import { getAppNotFoundPageService } from '../app-not-found-page.service'
import type { AppNotFoundPageStoreModel } from './app-not-found-page-store.types'

//const storeKey = 'app-not-found-page'

export const useAppNotFoundPageStore = (): AppNotFoundPageStoreModel => {
  const appNotFoundPageApiModel = useAppNotFoundPageApi()
  const pageStoreModel = usePageStore()

  const appNotFoundPageService = getAppNotFoundPageService()

  return {
    async load(dataOptions: AppNotFoundPageApiDataOptions): Promise<void> {
      const data = await appNotFoundPageApiModel.get(dataOptions)

      pageStoreModel.load({
        pageKey: appNotFoundPageService.createPageKey(dataOptions.locale),
        pageTitle: data.pageTitle,
      })
    },
  }
}
