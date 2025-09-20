import { getPageStoreService } from '~/utils/infrastructure/page/store/page-store.service'
import { getAppNotFoundPageService } from './app-not-found-page.service'
import { useAppNotFoundPageResources } from './resources/app-not-found-page-resources.composable'

export const useAppNotFoundPage = () => {
  const appNotFoundPageResourcesModel = useAppNotFoundPageResources()

  const appNotFoundPageService = getAppNotFoundPageService()
  const pageStoreService = getPageStoreService()

  watchEffect(() => {
    pageStoreService.pageKey.value = appNotFoundPageService.createPageKey()
    pageStoreService.pageTitle.value = appNotFoundPageResourcesModel.getTitle()
  })
}
