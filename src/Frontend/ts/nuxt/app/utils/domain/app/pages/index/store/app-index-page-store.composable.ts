import { usePageStore } from '~/utils/infrastructure/page/store/page-store.composable'
import { useAppIndexPageApi } from '../api/app-index-page-api.composable'
import type { AppIndexPageApiDataOptions } from '../api/app-index-page-api.types'
import { getAppIndexPageService } from '../app-index-page.service'
import type { AppIndexPageStoreModel } from './app-index-page-store.types'

//const storeKey = 'app-index-page'

export const useAppIndexPageStore = (): AppIndexPageStoreModel => {
  const appIndexPageApiModel = useAppIndexPageApi()
  const pageStoreModel = usePageStore()

  const appIndexPageService = getAppIndexPageService()

  return {
    async load(dataOptions: AppIndexPageApiDataOptions): Promise<void> {
      const data = await appIndexPageApiModel.get(dataOptions)

      pageStoreModel.load({
        pageKey: appIndexPageService.createPageKey(dataOptions.locale),
        pageTitle: data.pageTitle,
      })
    },
  }
}
