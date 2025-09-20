import { getPageStoreService } from '~/utils/infrastructure/page/store/page-store.service'
import { useAppAboutPageResources } from './resources/app-about-page-resources.composable'
import { getAppAboutPageService } from './app-about-page.service'

export const useAppAboutPage = (): void => {
  const appAboutPageResourcesModel = useAppAboutPageResources()

  const appAboutPageService = getAppAboutPageService()
  const pageStoreService = getPageStoreService()

  watchEffect(() => {
    pageStoreService.pageKey.value = appAboutPageService.createPageKey()
    pageStoreService.pageTitle.value = appAboutPageResourcesModel.getTitle()
  })
}
