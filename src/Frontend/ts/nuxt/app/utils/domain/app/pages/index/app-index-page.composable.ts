import { getPageStoreService } from '~/utils/infrastructure/page/store/page-store.service'
import { useAppIndexPageResources } from './resources/app-index-page-resources.composable'
import { getAppIndexPageService } from './app-index-page.service'

export const useAppIndexPage = (): void => {
  const appIndexPageResourcesModel = useAppIndexPageResources()

  const appIndexPageService = getAppIndexPageService()
  const pageStoreService = getPageStoreService()

  watchEffect(() => {
    pageStoreService.pageKey.value = appIndexPageService.createPageKey()
    pageStoreService.pageTitle.value = appIndexPageResourcesModel.getTitle()
  })
}
