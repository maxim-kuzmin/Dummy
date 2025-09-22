import { usePageStore } from '~/utils/infrastructure/page/store/page-store.composable'
import { useAppAboutPageResources } from './resources/app-about-page-resources.composable'
import { getAppAboutPageService } from './app-about-page.service'

export const useAppAboutPage = (): void => {
  const appAboutPageResourcesModel = useAppAboutPageResources()
  const pageStoreModel = usePageStore()

  const appAboutPageService = getAppAboutPageService()

  watchEffect(load)

  function load() {
    pageStoreModel.pageKey.value = appAboutPageService.createPageKey()

    pageStoreModel.pageTitle.value = appAboutPageResourcesModel.getTitle()
  }
}
